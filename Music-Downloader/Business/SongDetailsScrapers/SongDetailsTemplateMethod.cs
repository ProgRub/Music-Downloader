using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.Enums;
using Business.Services;
using DB.Entities;
using HtmlAgilityPack;

namespace Business.SongDetailsScrapers
{
	public abstract class SongDetailsTemplateMethod
	{
		internal event EventHandler<SongFileProgressEventArgs> NotifySongFileProgress;
		private static readonly IDictionary<string, int> _alreadyVisitedAlbumPages = new Dictionary<string, int>();
		private readonly ISet<SongFileDTO> _songs;
		internal int ThreadId { get; }

		private static readonly IDictionary<string, List<SemaphoreSlim>> _albumsBeingChecked =
			new Dictionary<string, List<SemaphoreSlim>>();

		private static readonly object _checkAlbumsMutex = new();
		private static readonly object _accessExceptionsMutex = new();
		private static readonly object _accessDBMutex = new();
		internal SongFileDTO CurrentSong { get; set; }

		private static readonly IDictionary<string, string> _urlReplacements =
			UrlReplacementService.Instance.GetAllUrlReplacements();

		private static readonly IEnumerable<YearLyricsChangeDetailsException> _allExceptions =
			ExceptionsService.Instance.GetAllExceptions();

		internal static SemaphoreSlim SemaphoreErrorRaised { get; } = new(1, 1);
		internal static SemaphoreSlim SemaphoreErrorHandled { get; } = new(0, 1);

		internal static ISet<SongDetailsTemplateMethod> DetailsGetters { get; } =
			new HashSet<SongDetailsTemplateMethod>();

		internal static int ThreadIdWithError { get; private set; }
		internal bool SkipYear { get; set; }
		internal bool SkipLyrics { get; set; }

		protected HtmlDocument HtmlDocumentOfSingle { get; set; }


		internal SongDetailsTemplateMethod(ISet<SongFileDTO> songs, int threadId)
		{
			_songs = songs;
			ThreadId = threadId;
			lock (_checkAlbumsMutex)
			{
				DetailsGetters.Add(this);
			}
		}

		internal void GetYearAndLyricsOfSongs()
		{
			foreach (var song in _songs)
			{
				CurrentSong = song;
				
				CurrentSong.Album = SongFileDTO.RemoveWordsInParenthesisFromWord(new List<string>() { "Deluxe" }, CurrentSong.Album);
				CurrentSong.Title = SongFileDTO.RemoveWordsInParenthesisFromWord(new List<string>() { "feat", "Feat", "bonus", "Bonus", "Conclusion", "Vocal Mix", "Extended" }, CurrentSong.Title);
				RaiseEvent(SongFileProgress.GettingYear);
				bool haveToGetSongYear, haveToGetSongLyrics;
				lock (_accessExceptionsMutex)
				{
					haveToGetSongYear = !(!CurrentSong.IsSingle && _allExceptions.Any(e =>
						                      e.Type == ChangeDetailsExceptionType.SkipAlbumYear &&
						                      e.OriginalAlbum.Equals(CurrentSong.Album,
							                      StringComparison.OrdinalIgnoreCase) &&
						                      e.OriginalArtist.Equals(CurrentSong.AlbumArtist,
							                      StringComparison.OrdinalIgnoreCase)) ||
					                      CurrentSong.IsSingle && _allExceptions.Any(e =>
						                      e.Type == ChangeDetailsExceptionType.SkipLyrics &&
						                      e.OriginalTitle.Equals(CurrentSong.Title,
							                      StringComparison.OrdinalIgnoreCase) &&
						                      e.OriginalArtist.Equals(CurrentSong.AlbumArtist,
							                      StringComparison.OrdinalIgnoreCase)));
					haveToGetSongLyrics = !_allExceptions.Any(e => e.Type == ChangeDetailsExceptionType.SkipLyrics &&
					                                               e.OriginalTitle.Equals(CurrentSong.Title,
						                                               StringComparison.OrdinalIgnoreCase) &&
					                                               e.OriginalArtist.Equals(CurrentSong.AlbumArtist,
						                                               StringComparison.OrdinalIgnoreCase));
				}

				if (haveToGetSongYear)
					SetSongYear();
				RaiseEvent(SongFileProgress.GettingLyrics);
				if (haveToGetSongLyrics)
					SetSongLyrics();
				lock (_accessDBMutex)
				{
					CurrentSong.SaveToFile();
				}
				RaiseEvent(SongFileProgress.AddingToService);
				BusinessFacade.Instance.AddSongToService(CurrentSong);
				RaiseEvent(SongFileProgress.FileDone);
			}
		}

		private void SetSongLyrics()
		{
			if (CurrentSong.IsSingle)
			{
				CurrentSong.Lyrics = GetLyrics(HtmlDocumentOfSingle);
				return;
			}

			var errorHappened = false;
			var originalSong = CurrentSong.Copy();

			YearLyricsChangeDetailsException? changeDetailsException;
			lock (_accessExceptionsMutex)
			{
				changeDetailsException = _allExceptions.FirstOrDefault(e =>
					e.Type == ChangeDetailsExceptionType.ChangeDetailsForLyrics &&
					e.OriginalTitle.Equals(originalSong.Title, StringComparison.OrdinalIgnoreCase) &&
					e.OriginalAlbum.Equals(originalSong.Album, StringComparison.OrdinalIgnoreCase) &&
					e.OriginalArtist.Equals(originalSong.AlbumArtist, StringComparison.OrdinalIgnoreCase));
			}

			if (changeDetailsException != null)
			{
				CurrentSong.AlbumArtist = changeDetailsException.NewArtist;
				CurrentSong.Title = changeDetailsException.NewTitle;
			}

			while (!DoesWebpageExist(GetUrlFromSong(false)))
			{
				ThreadIdWithError = ThreadId;
				SemaphoreErrorRaised.Wait();
				Process.Start(new ProcessStartInfo("cmd",
						$"/c start microsoft-edge:https://www.google.com.tr/search?q={(CurrentSong.AlbumArtist.Replace(" &", "") + "+" + CurrentSong.Title.Replace(" &", "")).Replace(" ", "+")}+lyrics+site:Genius.com")
					{CreateNoWindow = true});
				RaiseEvent(SongFileProgress.GettingLyricsException);
				SemaphoreErrorHandled.Wait();
				SemaphoreErrorRaised.Release();
				if (SkipLyrics)
				{
					SkipLyrics = false;
					ExceptionsService.Instance.AddSkipLyricsException(originalSong);
					return;
				}

				errorHappened = true;
			}

			if (errorHappened)
			{
				ExceptionsService.Instance.AddCorrectionForLyricsException(originalSong, CurrentSong);
			}

			CurrentSong.Lyrics = GetLyrics();
		}

		private void SetSongYear()
		{
			var errorHappened = false;
			var originalSong = CurrentSong.Copy();
			if (CurrentSong.IsSingle)
			{
				YearLyricsChangeDetailsException? changeDetailsException;
				lock (_accessExceptionsMutex)
				{
					changeDetailsException = _allExceptions.FirstOrDefault(e =>
						e.Type == ChangeDetailsExceptionType.ChangeDetailsForLyrics &&
						e.OriginalTitle.Equals(originalSong.Title, StringComparison.OrdinalIgnoreCase) &&
						e.OriginalAlbum.Equals(originalSong.Album, StringComparison.OrdinalIgnoreCase) &&
						e.OriginalArtist.Equals(originalSong.AlbumArtist, StringComparison.OrdinalIgnoreCase));
				}

				if (changeDetailsException != null)
				{
					CurrentSong.AlbumArtist = changeDetailsException.NewArtist;
					CurrentSong.Title = changeDetailsException.NewTitle;
				}

				while (!DoesWebpageExist(GetUrlFromSong(false)))
				{
					ThreadIdWithError = ThreadId;
					SemaphoreErrorRaised.Wait();
					Process.Start(new ProcessStartInfo("cmd",
							$"/c start microsoft-edge:https://www.google.com.tr/search?q={(CurrentSong.AlbumArtist.Replace(" &", "") + "+" + CurrentSong.Title.Replace(" &", "")).Replace(" ", "+")}+lyrics+site:Genius.com")
						{CreateNoWindow = true});
					RaiseEvent(SongFileProgress.GettingYearException);
					SemaphoreErrorHandled.Wait();
					SemaphoreErrorRaised.Release();
					if (SkipYear)
					{
						SkipYear = false;
						ExceptionsService.Instance.AddSkipLyricsException(originalSong);
						return;
					}

					errorHappened = true;
				}

				if (errorHappened)
				{
					ExceptionsService.Instance.AddCorrectionForLyricsException(originalSong, CurrentSong);
				}

				CurrentSong.Year = GetYearOfSingle();
				return;
			}

			if (_alreadyVisitedAlbumPages.ContainsKey(originalSong.AlbumArtist + originalSong.Album))
			{
				CurrentSong.Year = _alreadyVisitedAlbumPages[originalSong.AlbumArtist + originalSong.Album];
			}
			else
			{
				var semaphoreIndex = -1;
				var waitAtSemaphore = false;
				lock (_checkAlbumsMutex)
				{
					if (_albumsBeingChecked.ContainsKey(originalSong.Album))
					{
						_albumsBeingChecked[originalSong.Album].Add(new SemaphoreSlim(0, 1));
						semaphoreIndex = _albumsBeingChecked[originalSong.Album].Count - 1;
						waitAtSemaphore = true;
					}
					else
					{
						_albumsBeingChecked.Add(originalSong.Album, new List<SemaphoreSlim>());
					}
				}

				if (waitAtSemaphore)
				{
					_albumsBeingChecked[originalSong.Album][semaphoreIndex].Wait();
				}
				else
				{
					YearLyricsChangeDetailsException? changeDetailsException;
					lock (_accessExceptionsMutex)
					{
						changeDetailsException = _allExceptions.FirstOrDefault(e =>
							e.Type == ChangeDetailsExceptionType.ChangeDetailsForAlbumYear &&
							e.OriginalAlbum.Equals(originalSong.Album, StringComparison.OrdinalIgnoreCase) &&
							e.OriginalArtist.Equals(originalSong.AlbumArtist, StringComparison.OrdinalIgnoreCase));
					}

					if (changeDetailsException != null)
					{
						CurrentSong.Album = changeDetailsException.NewAlbum;
						CurrentSong.AlbumArtist = changeDetailsException.NewArtist;
					}

					while (!DoesWebpageExist(GetUrlFromSong(true)))
					{
						ThreadIdWithError = ThreadId;
						SemaphoreErrorRaised.Wait();
						Process.Start(new ProcessStartInfo("cmd",
								$"/c start microsoft-edge:https://www.google.com.tr/search?q={(CurrentSong.AlbumArtist.Replace(" &", "") + "+" + CurrentSong.Album.Replace(" &", "")).Replace(" ", "+")}+site:Genius.com")
							{CreateNoWindow = true});
						RaiseEvent(SongFileProgress.GettingYearException);
						SemaphoreErrorHandled.Wait();
						SemaphoreErrorRaised.Release();
						if (SkipYear)
						{
							SkipYear = false;
							ExceptionsService.Instance.AddSkipAlbumYearException(originalSong);
							_alreadyVisitedAlbumPages.Add(originalSong.AlbumArtist + originalSong.Album, CurrentSong.Year);
							foreach (var semaphore in _albumsBeingChecked[originalSong.Album])
							{
								semaphore.Release();
							}

							_albumsBeingChecked.Remove(originalSong.Album);
							return;
						}

						errorHappened = true;
					}

					if (errorHappened)
					{
						ExceptionsService.Instance.AddCorrectionForAlbumYearException(originalSong, CurrentSong);
					}

					CurrentSong.Year = GetYearOfAlbumTrack();
					_alreadyVisitedAlbumPages.Add(originalSong.AlbumArtist + originalSong.Album, CurrentSong.Year);
					foreach (var semaphore in _albumsBeingChecked[originalSong.Album])
					{
						semaphore.Release();
					}

					_albumsBeingChecked.Remove(originalSong.Album);
				}
			}
		}

		private void RaiseEvent(SongFileProgress progress)
		{
			var url = progress == SongFileProgress.GettingYearException
				? GetUrlFromSong(!CurrentSong.IsSingle)
				: GetUrlFromSong(false);
			NotifySongFileProgress?.Invoke(this,
				new SongFileProgressEventArgs
				{
					Song = CurrentSong,
					ThreadId = ThreadId,
					Progress = progress,
					Url = url
				});
		}

		private static bool DoesWebpageExist(string url)
		{
			var request = (HttpWebRequest) WebRequest.Create(url);
			HttpWebResponse response;
			try
			{
				response = (HttpWebResponse) request.GetResponse();
			}
			catch (WebException e)
			{
				response = (HttpWebResponse) e.Response;
			}

			return response.StatusCode == HttpStatusCode.OK;
		}


		protected static string MakeUrlReplacementsOnString(string detailParameter, bool forSongTitle,bool forAlbumName)
		{
			var detail = detailParameter.ToLower();
			if (forAlbumName)
			{
				detail = detail.Replace(".", " ");
			}
			foreach (var (key, value) in _urlReplacements)
			{
				detail = detail.Replace(key, value);
			}

			var auxList = detail.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
			for (var index = 0; index < auxList.Length; index++)
			{
				auxList[index] = auxList[index].Trim();
			}

			detail = string.Join("-", auxList);
			if (!forSongTitle)
			{
				return char.ToUpper(detail[0]) + detail[1..].ToLower();
			}

			return detail.ToLower();
		}

		protected static HtmlDocument GetHtmlDocFromUrl(string url)
		{
			return new HtmlWeb().Load(url);
		}

		protected string GetDecodedInnerText(HtmlNode node)
		{
			return WebUtility.HtmlDecode(node.InnerText);
		}

		internal abstract int GetYearOfSingle();
		internal abstract int GetYearOfAlbumTrack();
		internal abstract string GetLyrics();
		internal abstract string GetLyrics(HtmlDocument htmlDocument);
		internal abstract string GetUrlFromSong(bool forAlbumYear);
	}
}