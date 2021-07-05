using System.Collections.Generic;
using System.Windows.Forms;
using Business.Commands;

namespace Forms.Commands.ManageGrimeArtists
{
	public class CommandAddGrimeArtistToListBox : ICommand
	{
		private ICollection<string> _grimeArtists;
		private ListBox _listBox;
		private string _grimeArtist;
		private int _itemIndex;

		public CommandAddGrimeArtistToListBox(string grimeArtist, ListBox listBox, ref ICollection<string> grimeArtists)
		{
			_grimeArtist = grimeArtist;
			_listBox = listBox;
			_itemIndex = _listBox.Items.Count;
			_grimeArtists = grimeArtists;
		}

		public void Execute()
		{
			_grimeArtists.Add(_grimeArtist);
			_listBox.Items.Add(_grimeArtist);
			_listBox.SelectedIndex = _itemIndex;
		}

		public void Undo()
		{
			_grimeArtists.Remove(_grimeArtist);
			_listBox.Items.Remove(_grimeArtist);
		}
		
		public void Redo() => Execute();
	}
}