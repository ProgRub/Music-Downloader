using System.Windows.Forms;
using Business.Commands;
using Business.DTOs;
using Business.Enums;

namespace Forms.Commands.ManageExceptions
{
	public class CommandAddExceptionToListBox : ICommand
	{
		private readonly string _item;
		private readonly ListBox _listBox;
		private readonly ExceptionType _selectedExceptionType;
		private readonly ManageExceptionsScreen _screen;
		private readonly int _itemIndex;

		public CommandAddExceptionToListBox(string item, ListBox listBox, ExceptionType selectedExceptionType,
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
		}

		public void Undo()
		{
			if (_selectedExceptionType == _screen.SelectedExceptionType)
				_listBox.Items.Remove(_item);
		}

		public void Redo() => Execute();
	}
}