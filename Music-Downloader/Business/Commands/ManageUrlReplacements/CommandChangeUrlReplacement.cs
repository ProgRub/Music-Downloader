using System;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandChangeUrlReplacement : ICommand
	{
		private ExceptionDTO _oldException, _newException;
		private YearLyricsChangeDetailsException _exception;


		public CommandChangeUrlReplacement(ExceptionDTO oldException,ExceptionDTO newException)
		{
			_newException = newException;
			_oldException = oldException;
			_exception = ExceptionsService.Instance.GetExceptionFromDTO(_oldException);
		}

		public void Execute()
		{
			switch (_exception.Type)
			{
				case ChangeDetailsExceptionType.ChangeDetailsForAlbumYear:
					_exception.OriginalArtist = _newException.OriginalArtist;
					_exception.OriginalAlbum = _newException.OriginalAlbum;
					_exception.NewArtist = _newException.NewArtist;
					_exception.NewAlbum = _newException.NewAlbum;
					break;
				case ChangeDetailsExceptionType.ChangeDetailsForLyrics:
					_exception.OriginalArtist = _newException.OriginalArtist;
					_exception.OriginalTitle = _newException.OriginalTitle;
					_exception.NewArtist = _newException.NewArtist;
					_exception.NewTitle = _newException.NewTitle;
					break;
				case ChangeDetailsExceptionType.SkipAlbumYear:
					_exception.OriginalArtist = _newException.OriginalArtist;
					_exception.OriginalAlbum = _newException.OriginalAlbum;
					break;
				case ChangeDetailsExceptionType.SkipLyrics:
					_exception.OriginalArtist = _newException.OriginalArtist;
					_exception.OriginalTitle = _newException.OriginalTitle;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Undo()
		{
			switch (_exception.Type)
			{
				case ChangeDetailsExceptionType.ChangeDetailsForAlbumYear:
					_exception.OriginalArtist = _oldException.OriginalArtist;
					_exception.OriginalAlbum = _oldException.OriginalAlbum;
					_exception.NewArtist = _oldException.NewArtist;
					_exception.NewAlbum = _oldException.NewAlbum;
					break;
				case ChangeDetailsExceptionType.ChangeDetailsForLyrics:
					_exception.OriginalArtist = _oldException.OriginalArtist;
					_exception.OriginalTitle = _oldException.OriginalTitle;
					_exception.NewArtist = _oldException.NewArtist;
					_exception.NewTitle = _oldException.NewTitle;
					break;
				case ChangeDetailsExceptionType.SkipAlbumYear:
					_exception.OriginalArtist = _oldException.OriginalArtist;
					_exception.OriginalAlbum = _oldException.OriginalAlbum;
					break;
				case ChangeDetailsExceptionType.SkipLyrics:
					_exception.OriginalArtist = _oldException.OriginalArtist;
					_exception.OriginalTitle = _oldException.OriginalTitle;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Redo()
		{
			Execute();
		}
	}
}