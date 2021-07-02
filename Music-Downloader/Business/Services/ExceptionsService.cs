using System.Collections.Generic;
using Business.DTOs;
using DB.Entities;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class ExceptionsService
	{
		private IYearLyricsChangeDetailsExceptionRepository _changeDetailsExceptionRepository;

		private ExceptionsService()
		{
		}

		public static ExceptionsService Instance { get; } = new();

		internal void AddSkipYearException(SongFileDTO song)
		{
			YearLyricsChangeDetailsException exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album, OriginalTitle = song.Title,
				Type = ExceptionType.SkipYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddSkipLyricsException(SongFileDTO song)
		{
			YearLyricsChangeDetailsException exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album, OriginalTitle = song.Title,
				Type = ExceptionType.SkipLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForYearException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			YearLyricsChangeDetailsException exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album, NewTitle = newSong.Title,
				Type = ExceptionType.ChangeDetailsForYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForLyricsException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			YearLyricsChangeDetailsException exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album, NewTitle = newSong.Title,
				Type = ExceptionType.ChangeDetailsForLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.SkipYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.SkipLyrics);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.ChangeDetailsForYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ExceptionType.ChangeDetailsForLyrics);

		internal void SaveChanges() => _changeDetailsExceptionRepository.SaveChanges();
	}
}