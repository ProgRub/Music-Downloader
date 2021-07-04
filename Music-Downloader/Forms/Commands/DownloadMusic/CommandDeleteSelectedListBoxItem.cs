using System.Windows.Forms;
using Business.Commands;

namespace Forms.Commands.DownloadMusic
{
	public class CommandDeleteSelectedListBoxItem : ICommand
	{
		private ListBox _listBox;
		private object _item;
		private int _itemIndex;

		public CommandDeleteSelectedListBoxItem(ListBox listBox)
		{
			_listBox = listBox;
			_item = _listBox.SelectedItem;
			_itemIndex = _listBox.SelectedIndex;
		}

		public void Execute()
		{
			_listBox.Items.Remove(_item);
		}

		public void Undo()
		{
			_listBox.Items.Insert(_itemIndex, _item);
			_listBox.SelectedIndex = _itemIndex;
		}

		public void Redo()
		{
			Execute();
		}
	}
}