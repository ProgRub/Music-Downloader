using System.Collections.Generic;
using System.Diagnostics;
using Business.Commands;
using Business.DTOs;

namespace Forms.Commands.ManageExceptions
{
	public class CommandChangeExceptionInList : ICommand
	{
		private IList<ExceptionDTO> _exceptions;
		private ExceptionDTO _oldException, _newException;

		public CommandChangeExceptionInList(ref IList<ExceptionDTO> exceptions, ExceptionDTO oldException,
			ExceptionDTO newException)
		{
			_exceptions = exceptions;
			_oldException = oldException;
			_newException = newException;
		}

		public void Execute()
		{
			for (var index = 0; index < _exceptions.Count; index++)
			{
				if (_exceptions[index].Id != _oldException.Id) continue;
				_exceptions[index] = _newException;
				return;
			}
		}

		public void Undo()
		{
			for (var index = 0; index < _exceptions.Count; index++)
			{
				if (_exceptions[index].Id != _oldException.Id) continue;
				_exceptions[index] = _oldException;
				return;
			}
		}

		public void Redo()
		{
			Execute();
		}
	}
}