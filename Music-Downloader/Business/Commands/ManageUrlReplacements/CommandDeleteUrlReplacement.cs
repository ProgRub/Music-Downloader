using System;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandDeleteUrlReplacement:ICommand
	{
		private readonly string _urlReplacementKey;

		public CommandDeleteUrlReplacement(string urlReplacementKey)
		{
			_urlReplacementKey = urlReplacementKey;
		}

		public void Execute() => UrlReplacementService.Instance.RemoveUrlReplacement(_urlReplacementKey);

		public void Undo()
		{
			UrlReplacementService.Instance.AddUrlReplacement(_urlReplacementKey);
		}

		public void Redo() => Execute();
	}
}