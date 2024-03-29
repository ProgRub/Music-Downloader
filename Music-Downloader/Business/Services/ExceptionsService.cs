﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Business.DTOs;
using Business.Enums;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
	internal class ExceptionsService
	{
		private readonly IYearLyricsChangeDetailsExceptionRepository _changeDetailsExceptionRepository;

		private readonly ICollection<YearLyricsChangeDetailsException> _deletedExceptions =
			new List<YearLyricsChangeDetailsException>();

		private readonly ICollection<YearLyricsChangeDetailsException> _addedExceptions =
			new List<YearLyricsChangeDetailsException>();

		private ExceptionsService()
		{
			_changeDetailsExceptionRepository = new YearLyricsChangeDetailsExceptionRepository(Database.GetContext());
		}

		internal static ExceptionsService Instance { get; } = new();

		internal IEnumerable<YearLyricsChangeDetailsException> ForTest()
		{
			return _changeDetailsExceptionRepository.Find(e =>
				e.Type == ChangeDetailsExceptionType.ChangeDetailsForAlbumYear);
		}

		internal void AddSkipAlbumYearException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalAlbum = song.Album,
				Type = ChangeDetailsExceptionType.SkipAlbumYear
			};
			_addedExceptions.Add(exception);
		}

		internal void AddSkipLyricsException(SongFileDTO song)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = song.AlbumArtist, OriginalTitle = song.Title,
				Type = ChangeDetailsExceptionType.SkipLyrics
			};
			_addedExceptions.Add(exception);
		}

		internal void AddCorrectionForAlbumYearException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist, OriginalAlbum = originalSong.Album,
				NewArtist = newSong.AlbumArtist, NewAlbum = newSong.Album,
				Type = ChangeDetailsExceptionType.ChangeDetailsForAlbumYear
			};
			_addedExceptions.Add(exception);
		}

		internal void AddCorrectionForLyricsException(SongFileDTO originalSong, SongFileDTO newSong)
		{
			var exception = new YearLyricsChangeDetailsException
			{
				OriginalArtist = originalSong.AlbumArtist,
				OriginalAlbum = originalSong.Album,
				OriginalTitle = originalSong.Title,
				NewArtist = newSong.AlbumArtist, NewTitle = newSong.Title,
				Type = ChangeDetailsExceptionType.ChangeDetailsForLyrics
			};
			_addedExceptions.Add(exception);
		}

		internal void AddCorrectionForAlbumYearException(YearLyricsChangeDetailsException exception,
			bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_addedExceptions.Add(exception);
		}

		internal void AddCorrectionForLyricsException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_addedExceptions.Add(exception);
		}

		internal void AddSkipAlbumYearException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_addedExceptions.Add(exception);
		}

		internal void AddSkipLyricsException(YearLyricsChangeDetailsException exception, bool recentlyDeleted)
		{
			if (recentlyDeleted)
			{
				_deletedExceptions.Remove(exception);
				return;
			}

			_addedExceptions.Add(exception);
		}

		internal void RemoveException(YearLyricsChangeDetailsException exception)
		{
			if (!_addedExceptions.Remove(exception))
				_deletedExceptions.Add(exception);
		}


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

			foreach (var addedException in _addedExceptions)
			{
				_changeDetailsExceptionRepository.Add(addedException);
			}

			_changeDetailsExceptionRepository.SaveChanges();
			_deletedExceptions.Clear();
			_addedExceptions.Clear();
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
			try
			{
				switch (dto.Type)
				{
					case ExceptionType.ChangeDetailsForAlbumYear:
						return _changeDetailsExceptionRepository.Find(e =>
								e.Type ==ChangeDetailsExceptionType.ChangeDetailsForAlbumYear &&
								EF.Functions.Like(e.OriginalAlbum, dto.OriginalAlbum) &&
								EF.Functions.Like(e.OriginalArtist, dto.OriginalArtist))
							.First();
					case ExceptionType.ChangeDetailsForLyrics:
						return _changeDetailsExceptionRepository.Find(e =>
								e.Type == ChangeDetailsExceptionType.ChangeDetailsForLyrics &&
								EF.Functions.Like(e.OriginalAlbum, dto.OriginalAlbum) &&
								EF.Functions.Like(e.OriginalArtist, dto.OriginalArtist) &&
								EF.Functions.Like(e.OriginalTitle, dto.OriginalTitle))
							.First();
					case ExceptionType.SkipAlbumYear:
						return _changeDetailsExceptionRepository.Find(e =>
								e.Type == ChangeDetailsExceptionType.SkipAlbumYear &&
								EF.Functions.Like(e.OriginalAlbum, dto.OriginalAlbum) &&
								EF.Functions.Like(e.OriginalArtist, dto.OriginalArtist))
							.First();
					case ExceptionType.SkipLyrics:
						return _changeDetailsExceptionRepository.Find(e =>
								e.Type == ChangeDetailsExceptionType.SkipLyrics &&
								EF.Functions.Like(e.OriginalArtist, dto.OriginalArtist) &&
								EF.Functions.Like(e.OriginalTitle, dto.OriginalTitle))
							.First();
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			catch (InvalidOperationException e)
			{
				switch (dto.Type)
				{
					case ExceptionType.ChangeDetailsForAlbumYear:
						return _addedExceptions.ToList()
							.FirstOrDefault(e =>
								e.Type == ChangeDetailsExceptionType.ChangeDetailsForAlbumYear &&
								e.OriginalAlbum.Equals(dto.OriginalAlbum, StringComparison.OrdinalIgnoreCase) &&
								e.OriginalArtist.Equals(dto.OriginalArtist, StringComparison.OrdinalIgnoreCase));
					case ExceptionType.ChangeDetailsForLyrics:
						return _addedExceptions.ToList()
							.FirstOrDefault(e =>
								e.Type == ChangeDetailsExceptionType.ChangeDetailsForLyrics &&
								e.OriginalTitle.Equals(dto.OriginalTitle, StringComparison.OrdinalIgnoreCase) &&
								e.OriginalAlbum.Equals(dto.OriginalAlbum, StringComparison.OrdinalIgnoreCase) &&
								e.OriginalArtist.Equals(dto.OriginalArtist, StringComparison.OrdinalIgnoreCase));
					case ExceptionType.SkipAlbumYear:
						return _addedExceptions.ToList()
							.FirstOrDefault(e =>
								e.Type == ChangeDetailsExceptionType.SkipAlbumYear &&
								e.OriginalAlbum.Equals(dto.OriginalAlbum, StringComparison.OrdinalIgnoreCase) &&
								e.OriginalArtist.Equals(dto.OriginalArtist, StringComparison.OrdinalIgnoreCase));
					case ExceptionType.SkipLyrics:
						return _addedExceptions.ToList()
							.FirstOrDefault(e =>
								e.Type == ChangeDetailsExceptionType.SkipLyrics &&
								e.OriginalTitle.Equals(dto.OriginalTitle, StringComparison.OrdinalIgnoreCase) &&
								e.OriginalArtist.Equals(dto.OriginalArtist, StringComparison.OrdinalIgnoreCase));
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}