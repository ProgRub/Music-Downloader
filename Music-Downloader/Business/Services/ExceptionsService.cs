using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Business.DTOs;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	internal class ExceptionsService
	{
		private readonly IYearLyricsChangeDetailsExceptionRepository _changeDetailsExceptionRepository;

		private readonly ICollection<YearLyricsChangeDetailsException> _deletedExceptions  =
			new List<YearLyricsChangeDetailsException>();

		private ExceptionsService()
		{
			_changeDetailsExceptionRepository = new YearLyricsChangeDetailsExceptionRepository(Database.GetContext());
		}

		internal static ExceptionsService Instance { get; } = new();

		internal void AddSkipAlbumYearException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album,
				Type = ChangeDetailsExceptionType.SkipAlbumYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddSkipLyricsException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalTitle = song.Title,
				Type = ChangeDetailsExceptionType.SkipLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForAlbumYearException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album,
				Type = ChangeDetailsExceptionType.ChangeDetailsForAlbumYear
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForLyricsException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewTitle = newSong.Title,
				Type = ChangeDetailsExceptionType.ChangeDetailsForLyrics
			};
			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForAlbumYearException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddCorrectionForLyricsException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddSkipAlbumYearException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void AddSkipLyricsException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_changeDetailsExceptionRepository.Add(exception);
		}

		internal void RemoveException(YearLyricsChangeDetailsException exception) => _deletedExceptions.Add(exception);
		

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipAlbumYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ChangeDetailsExceptionType.SkipAlbumYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllSkipLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ChangeDetailsExceptionType.SkipLyrics);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForAlbumYearExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ChangeDetailsExceptionType.ChangeDetailsForAlbumYear);

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllChangeDetailsForLyricsExceptions() =>
			_changeDetailsExceptionRepository.Find(e => e.Type == ChangeDetailsExceptionType.ChangeDetailsForLyrics);

		internal void SaveChanges()
		{
			foreach (var deletedException in _deletedExceptions)
			{
				_changeDetailsExceptionRepository.Remove(deletedException);
			}
			_changeDetailsExceptionRepository.SaveChanges();
		} 

		internal IEnumerable<YearLyricsChangeDetailsException> GetAllExceptions()
		{
			var allExceptions = new List<YearLyricsChangeDetailsException>();
			allExceptions.AddRange(GetAllSkipAlbumYearExceptions());
			allExceptions.AddRange(GetAllSkipLyricsExceptions());
			allExceptions.AddRange(GetAllChangeDetailsForAlbumYearExceptions());
			allExceptions.AddRange(GetAllChangeDetailsForLyricsExceptions());
			return allExceptions;
		}

		internal YearLyricsChangeDetailsException GetExceptionFromDTO(ExceptionDTO dto)
		{
			return _changeDetailsExceptionRepository.Find(e =>
				e.OriginalAlbum == dto.OriginalAlbum && e.OriginalArtist == dto.OriginalArtist &&
				e.OriginalTitle == dto.OriginalTitle && e.Type == (ChangeDetailsExceptionType) dto.Type).First();
		}
	}
}