using System;
using System.Collections.Generic;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandAddUrlReplacement : ICommand
	{
		private YearLyricsChangeDetailsException _exception;
		private IList<ExceptionDTO> _exceptions;
		private ExceptionDTO _exceptionDtoToAddToList;

		public CommandAddUrlReplacement(ExceptionDTO exception, ref IList<ExceptionDTO> exceptions)
		{
			_exceptionDtoToAddToList = exception;
			_exception = new YearLyricsChangeDetailsException()
			{
				OriginalArtist = exception.OriginalArtist, OriginalAlbum = exception.OriginalAlbum,
				OriginalTitle = exception.OriginalTitle, NewArtist = exception.NewArtist, NewAlbum = exception.NewAlbum,
				NewTitle = exception.NewTitle, Type = (ChangeDetailsExceptionType) exception.Type
			};
			_exceptions = exceptions;
		}

		public void Execute()
		{
			switch (_exception.Type)
			{
				case ChangeDetailsExceptionType.ChangeDetailsForAlbumYear:
					ExceptionsService.Instance.AddCorrectionForAlbumYearException(_exception,false);
					break;
				case ChangeDetailsExceptionType.ChangeDetailsForLyrics:
					ExceptionsService.Instance.AddCorrectionForLyricsException(_exception,false);
					break;
				case ChangeDetailsExceptionType.SkipAlbumYear:
					ExceptionsService.Instance.AddSkipAlbumYearException(_exception,false);
					break;
				case ChangeDetailsExceptionType.SkipLyrics:
					ExceptionsService.Instance.AddSkipLyricsException(_exception,false);
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