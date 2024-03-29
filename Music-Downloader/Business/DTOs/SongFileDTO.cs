﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Business.Enums;
using Business.Services;

namespace Business.DTOs
{
	public class SongFileDTO
	{
		public string Filename { get; set; }
		public string AlbumArtist { get; set; }
		public IEnumerable<string> ContributingArtists { get; set; }
		public string Album { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public int TrackNumber { get; set; }
		public int TotalTrackCount { get; set; }
		public int DiscNumber { get; set; }
		public int TotalDiscCount { get; set; }
		public int Year { get; set; }
		public string Lyrics { get; set; }
		public DateTime LastModified { get; private init; }
		public TimeSpan Duration { get; private init; }

		private static IDictionary<string, string> _genreReplacements = new Dictionary<string, string>
			{{"Alternativa", "Alternative"},{"Rap", "Hip Hop"}};

		public bool IsSingle => TotalTrackCount < 5 && DiscNumber == 1 && TotalDiscCount == 1;

		internal static SongFileDTO GetSongFileDTOFromFilePath(string filePath)
		{
			using var songFile = TagLib.File.Create(filePath);
			var albumArtist = songFile.Tag.FirstAlbumArtist;

			string genre;
			if (GrimeArtistService.Instance.GetAllGrimeArtists().Contains(albumArtist))
			{
				genre = "Grime";
			}
			else
			{
				genre = _genreReplacements.ContainsKey(songFile.Tag.FirstGenre)
					? _genreReplacements[songFile.Tag.FirstGenre]
					: songFile.Tag.FirstGenre;
			}

			if (albumArtist.Contains("King Gizzard"))
			{
				songFile.Tag.Performers = songFile.Tag.Performers.Select(e => e.Replace("And", "&")).ToArray();
				albumArtist = albumArtist.Replace("And", "&");
			}
			var fileName = Path.GetFileName(filePath);
			return new SongFileDTO
			{
				Filename = fileName,
				Album = RemoveWordsInParenthesisFromWord(new List<string>() {"Remaster", "Anniversary", "Expanded", "Digital Master" },
					songFile.Tag.Album),
				AlbumArtist = albumArtist,
				ContributingArtists = songFile.Tag.Performers,
				DiscNumber = (int) songFile.Tag.Disc,
				TrackNumber = (int) songFile.Tag.Track,
				Title = UnCensorTitle(RemoveWordsInParenthesisFromWord(new List<string>()
				{
					"Remaster", "Album Version", "Stereo", "Hidden Track", "Explicit",
					"explicit","Digital Master"
				}, songFile.Tag.Title)),
				Genre = genre,
				TotalTrackCount = (int) songFile.Tag.TrackCount,
				TotalDiscCount = (int) songFile.Tag.DiscCount,
				Year = (int) songFile.Tag.Year,
				Lyrics = songFile.Tag.Lyrics,
				LastModified = File.GetLastWriteTime(filePath),
				Duration=songFile.Properties.Duration
			};
		}

		public override string ToString()
		{
			return $"{AlbumArtist} - {Album} - {Title}";
		}

		internal static string UnCensorTitle(string title)
		{
			return title.Replace("f*ck", "fuck").Replace(
				"f***",
				"fuck").Replace("f**k", "fuck").Replace("sh*t", "shit").Replace(
				"s**t", "shit").Replace("sh**", "shit").Replace(
				"ni**as", "niggas").Replace("F*ck", "Fuck").Replace(
				"F**k", "Fuck").Replace("F***", "Fuck").Replace(
				"Sh*t", "Shit").Replace("S**t", "Shit").Replace(
				"Sh**", "Shit").Replace("Ni**as", "Niggas");
		}

		internal void RenameSongFile(RenameFileOptions renameOptions)
		{
			var toAdd = "";
			switch (renameOptions)
			{
				case RenameFileOptions.AddArtist:
				{
					toAdd = " (";
					var artistSplit = AlbumArtist.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();
					if ("The" == artistSplit[0])
					{
						artistSplit.Remove("The");
					}

					if (artistSplit.Count == 1)
					{
						toAdd += artistSplit[0];
					}
					else
					{
						toAdd = artistSplit.Aggregate(toAdd, (current, item) => current + item.ToUpper()[0]);
					}

					toAdd += ").mp3";
					Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					break;
				}
				case RenameFileOptions.AddAlbum:
					toAdd = " (";
					toAdd += Album;
					toAdd += ").mp3";
					Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					break;
				case RenameFileOptions.AddNumber:
					var fileNumber = 2;
					while (File.Exists(Path.Combine(DirectoriesService.Instance.MusicToDirectory, Filename)))
					{
						toAdd = " (" + fileNumber++ + ").mp3";
						Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					}

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(renameOptions), renameOptions, null);
			}
		}

		public void SaveToFile()
		{
			SongService.Instance.SetYearAndLyricsOfSong(this, Year, Lyrics);
			using var songFile =
				TagLib.File.Create(Path.Combine(DirectoriesService.Instance.MusicToDirectory, Filename));
			songFile.Tag.Lyrics = Lyrics;
			songFile.Tag.Year = (uint) Year;
			songFile.Tag.Genres = new[] {Genre};
			songFile.Tag.AlbumArtists = new[] {AlbumArtist};
			songFile.Tag.Performers = ContributingArtists.ToArray();
			songFile.Tag.Album = Album;
            songFile.Tag.Title = RemoveWordsInParenthesisFromWord(new List<string>()
            {
                "Remaster", "Album Version", "Stereo", "Explicit",
                "explicit", "Digital Master"
            }, songFile.Tag.Title);
			songFile.Save();
		}

		internal SongFileDTO Copy()
		{
			return new()
			{
				Filename = Filename,
				AlbumArtist = AlbumArtist,
				Album = Album,
				Title = Title,
				ContributingArtists = ContributingArtists,
				Genre = Genre,
				Lyrics = Lyrics,
				TrackNumber = TrackNumber,
				TotalTrackCount = TotalTrackCount,
				DiscNumber = DiscNumber,
				TotalDiscCount = TotalDiscCount,
				Year = Year
			};
		}

		internal static string RemoveWordsInParenthesisFromWord(IEnumerable<string> setOfWords, string wordPar)
		{
			var word = wordPar;
			if (!word.Contains("(") && !word.Contains("[")) return word.Trim();
			foreach (var wordToRemove in setOfWords)
			{
				var inRoundParenthesis = true;
				var startParenthesisPosition = -1;
				var endParenthesisPosition = -1;
				while (word.Contains(wordToRemove))
				{
					if (inRoundParenthesis)
					{
						startParenthesisPosition = word.IndexOf("(");
						endParenthesisPosition = word.IndexOf(")");
					}

					if (!inRoundParenthesis || startParenthesisPosition == -1)
					{
						startParenthesisPosition = word.IndexOf("[");
						endParenthesisPosition = word.IndexOf("]");
					}

					if (startParenthesisPosition != -1 && word
						.Substring(startParenthesisPosition, endParenthesisPosition - startParenthesisPosition + 1)
						.Contains(wordToRemove))
					{
						word = RemoveWordsInParenthesisFromWord(setOfWords,
							word.Remove(startParenthesisPosition - 1,
								endParenthesisPosition - startParenthesisPosition + 2));
					}
					else
					{
						if (!inRoundParenthesis)
						{
							if (word.Contains("("))
							{
								word = word.Replace(word.Substring(word.IndexOf(")") + 1),
									RemoveWordsInParenthesisFromWord(setOfWords,
										word.Substring(word.IndexOf(")") + 1)));
							}

							if (word.Contains("["))
							{
								word = word.Replace(word.Substring(word.IndexOf("]") + 1),
									RemoveWordsInParenthesisFromWord(setOfWords,
										word.Substring(word.IndexOf("]") + 1)));
							}
						}

						inRoundParenthesis = false;
					}
				}
			}

			return word.Trim();
		}

		public bool SongsHaveDifferentParameters(SongFileDTO other)
		{
			return !(AlbumArtist == other.AlbumArtist && Album == other.Album && Title == other.Title);
		}

		protected bool Equals(SongFileDTO other)
		{
			return Filename==other.Filename;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SongFileDTO) obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(AlbumArtist, Album, Title);
		}

		public static bool operator ==(SongFileDTO left, SongFileDTO right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(SongFileDTO left, SongFileDTO right)
		{
			return !Equals(left, right);
		}
	}
}