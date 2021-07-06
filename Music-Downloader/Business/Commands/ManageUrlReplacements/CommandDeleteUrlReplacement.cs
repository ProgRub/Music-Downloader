using System;
using System.Collections.Generic;
using Business.DTOs;
using Business.Services;
using DB.Entities;

namespace Business.Commands.ManageUrlReplacements
{
	public class CommandDeleteUrlReplacement:ICommand
	{
		private readonly string _urlReplacementKey;
		private readonly IDictionary<string, string> _urlReplacements;
		private readonly string _urlReplacementValue;

		public CommandDeleteUrlReplacement(string urlReplacementKey,ref IDictionary<string,string> urlReplacements)
		{
			_urlReplacementKey = urlReplacementKey;
			_urlReplacements = urlReplacements;
			_urlReplacementValue = _urlReplacements[_urlReplacementKey];
		}

		public void Execute()
		{
			_urlReplacements.Remove(_urlReplacementKey);
			UrlReplacementService.Instance.RemoveUrlReplacement(_urlReplacementKey);
		}

		public void Undo()
		{
			_urlReplacements.Add(_urlReplacementKey,_urlReplacementValue);
			UrlReplacementService.Instance.AddUrlReplacement(_urlReplacementKey);
		}

		public void Redo() => Execute();
	}
}