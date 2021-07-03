using System.Collections.Generic;
using System.Linq;
using Business.DTOs;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class ExceptionsService
	{
		private readonly IYearLyricsChangeDetailsExceptionRepository _changeDetailsExceptionRepository;

		private ExceptionsService()
		{
			_changeDetailsExceptionRepository = new YearLyricsChangeDetailsExceptionRepository(Database.GetContext());
		}

		public static ExceptionsService Instance { get; } = new();

		internal void AddSkipAlbumYearException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album, OriginalTitle = song.Title,
				Type = ExceptionType.SkipAlbumYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddSkipLyricsException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album, OriginalTitle = song.Title,
				Type = ExceptionType.SkipLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForAlbumYearException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album, NewTitle = newSong.Title,
				Type = ExceptionType.ChangeDetailsForAlbumYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForLyricsException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album, NewTitle = newSong.Title,
				Type = ExceptionType.ChangeDetailsForLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipAlbumYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.SkipAlbumYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.SkipLyrics);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForAlbumYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.ChangeDetailsForAlbumYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.ChangeDetailsForLyrics);

		internal void SaveChanges() => _changeDetailsExceptionRepository.SaveChanges();

		public IEnumerable<YearLyricsChangeDetailsException> GetAllExceptions()
		{
			var allExceptions = new List<YearLyricsChangeDetailsException>();
			allExceptions.AddRange(GetAllSkipAlbumYearExceptions());
			allExceptions.AddRange(GetAllSkipLyricsExceptions());
			allExceptions.AddRange(GetAllChangeDetailsForAlbumYearExceptions());
			allExceptions.AddRange(GetAllChangeDetailsForLyricsExceptions());
			return allExceptions;
		}
	}
}