using System.Collections.Generic;
using System.Windows.Forms;
using Business.Commands;
using Business.DTOs;

namespace Forms.Commands.ManageUrlReplacements
{
	public class CommandAddUrlReplacementToListbox:ICommand
	{
		private KeyValuePair<string,string> _urlReplacementPair;
		private ListBox _listBox;
		private int _itemIndex;
		private IDictionary<string, string> _urlReplacements;

		public CommandAddUrlReplacementToListbox(KeyValuePair<string,string> urlReplacementPair, ListBox listBox,
			ref IDictionary<string, string> urlReplacements)
		{
			_urlReplacementPair = urlReplacementPair;
			_listBox = listBox;
			_itemIndex = _listBox.Items.Count;
			_urlReplacements = urlReplacements;
		}
		public void Execute()
		{
			_urlReplacements.Add(_urlReplacementPair);
			_listBox.Items.Add($"\"{_urlReplacementPair.Key}\" --> \"{_urlReplacementPair.Value}\"");
			_listBox.SelectedIndex = _itemIndex;
		}

		public void Undo()  {
			_urlReplacements.Remove(_urlReplacementPair);
			_listBox.Items.Remove($"\"{_urlReplacementPair.Key}\" --> \"{_urlReplacementPair.Value}\"");
		}

		public void Redo() => Execute();
	}
}