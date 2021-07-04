using System.Windows.Forms;
using Business.Commands;
using Business.DTOs;

namespace Forms.Commands.ManageExceptions
{
	public class CommandAddItemToListBox : ICommand
	{
		private string _item;
		private ListBox _listBox;
		private ExceptionType _selectedExceptionType;
		private ManageExceptionsScreen _screen;
		private int _itemIndex;

		public CommandAddItemToListBox(string item, ListBox listBox, ExceptionType selectedExceptionType,
			ManageExceptionsScreen screen)
		{
			_item = item;
			_listBox = listBox;
			_selectedExceptionType = selectedExceptionType;
			_screen = screen;
			_itemIndex = _listBox.Items.Count;
		}

		public void Execute()
		{
			if (_selectedExceptionType != _screen.SelectedExceptionType) return;
			_listBox.Items.Add(_item);
			_listBox.SelectedIndex = _itemIndex;
		}

		public void Undo()
		{
			if (_selectedExceptionType == _screen.SelectedExceptionType)
				_listBox.Items.Remove(_item);
		}

		public void Redo() => Execute();
	}
}