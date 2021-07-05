using System;
using System.Collections.Generic;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandAddUrlReplacement : ICommand
	{
		private readonly string _whatToReplace;
		private readonly string _replacement;

		public CommandAddUrlReplacement(string whatToReplace,string replacement)
		{
			_whatToReplace = whatToReplace;
			_replacement = replacement;
		}

		public void Execute()
		{
			UrlReplacementService.Instance.AddUrlReplacement(_whatToReplace,_replacement);
		}

		public void Undo()
		{
			UrlReplacementService.Instance.RemoveUrlReplacement(_whatToReplace);
		}

		public void Redo() => Execute();
	}
}