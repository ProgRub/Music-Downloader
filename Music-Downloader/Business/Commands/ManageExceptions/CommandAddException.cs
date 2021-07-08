using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageExceptions
{
	public class CommandAddException : ICommand
	{
		private readonly YearLyricsChangeDetailsException _exception;
		private readonly IList<ExceptionDTO> _exceptions;
		private readonly ExceptionDTO _exceptionDtoToAddToList;

		public CommandAddException(ExceptionDTO exception, ref IList<ExceptionDTO> exceptions)
		{
			_exceptionDtoToAddToList = exception;
			_exception = new YearLyricsChangeDetailsException()
			{
				OriginalArtist = string.IsNullOrWhiteSpace(exception.OriginalArtist) ? null : exception.OriginalArtist,
				OriginalAlbum = string.IsNullOrWhiteSpace(exception.OriginalAlbum) ? null : exception.OriginalAlbum,
				OriginalTitle = string.IsNullOrWhiteSpace(exception.OriginalTitle) ? null : exception.OriginalTitle,
				NewArtist = string.IsNullOrWhiteSpace(exception.NewArtist) ? null : exception.NewArtist,
				NewAlbum = string.IsNullOrWhiteSpace(exception.NewAlbum) ? null : exception.NewAlbum,
				NewTitle = string.IsNullOrWhiteSpace(exception.NewTitle) ? null : exception.NewTitle,
				Type = (ChangeDetailsExceptionType) exception.Type
			};
			_exceptions = exceptions;
		}

		public void Execute()
		{
			switch (_exception.Type)
			{
				case ChangeDetailsExceptionType.ChangeDetailsForAlbumYear:
					ExceptionsService.Instance.AddCorrectionForAlbumYearException(_exception, false);
					break;
				case ChangeDetailsExceptionType.ChangeDetailsForLyrics:
					ExceptionsService.Instance.AddCorrectionForLyricsException(_exception, false);
					break;
				case ChangeDetailsExceptionType.SkipAlbumYear:
					ExceptionsService.Instance.AddSkipAlbumYearException(_exception, false);
					break;
				case ChangeDetailsExceptionType.SkipLyrics:
					ExceptionsService.Instance.AddSkipLyricsException(_exception, false);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			_exceptions.Add(_exceptionDtoToAddToList);
		}

		public void Undo()
		{
			ExceptionsService.Instance.RemoveException(_exception);
			_exceptions.Remove(_exceptionDtoToAddToList);
		}

		public void Redo() => Execute();
	}
}