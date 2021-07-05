using Business.Commands;
using Business.DTOs;

namespace Forms.Commands.ManageExceptions
{
	public class CommandSetSelectedExceptionType : ICommand
	{
		private readonly ExceptionType _exceptionType;
		private readonly ManageExceptionsScreen _screen;

		public CommandSetSelectedExceptionType(ExceptionType exceptionType, ManageExceptionsScreen screen)
		{
			_exceptionType = exceptionType;
			_screen = screen;
		}

		public void Execute()
		{
			_screen.SelectedExceptionType = _exceptionType;

		}

		public void Undo() => Execute();

		public void Redo() => Execute();
	}
}