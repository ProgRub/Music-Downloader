using System;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandDeleteUrlReplacement:ICommand
	{
		private YearLyricsChangeDetailsException _exception;

		public CommandDeleteUrlReplacement(ExceptionDTO exception)
		{
			_exception = ExceptionsService.Instance.GetExceptionFromDTO(exception);
		}

		public void Execute() => ExceptionsService.Instance.RemoveException(_exception);

		public void Undo()
		{
			switch (_exception.Type)
			{
				case ChangeDetailsExceptionType.ChangeDetailsForAlbumYear:
					ExceptionsService.Instance.AddCorrectionForAlbumYearException(_exception,true);
					break;
				case ChangeDetailsExceptionType.ChangeDetailsForLyrics:
					ExceptionsService.Instance.AddCorrectionForLyricsException(_exception,true);
					break;
				case ChangeDetailsExceptionType.SkipAlbumYear:
					ExceptionsService.Instance.AddSkipAlbumYearException(_exception,true);
					break;
				case ChangeDetailsExceptionType.SkipLyrics:
					ExceptionsService.Instance.AddSkipLyricsException(_exception,true);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Redo() => Execute();
	}
}