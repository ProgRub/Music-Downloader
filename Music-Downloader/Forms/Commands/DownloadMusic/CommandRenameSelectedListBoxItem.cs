using System.Windows.Forms;
using Business.Commands;

namespace Forms.Commands.DownloadMusic
{
    public class CommandRenameSelectedListBoxItem : ICommand
    {
        private string _newText, _oldText;
        private ListBox _listBox;
        private int _itemIndex;

        public CommandRenameSelectedListBoxItem(string newText, ListBox listBox)
        {
            _listBox = listBox;
            _itemIndex = _listBox.SelectedIndex;
            _oldText = _listBox.Items[_itemIndex].ToString();
            _newText = newText;
        }

        public void Execute() => _listBox.Items[_itemIndex] = _newText;

        public void Undo() => _listBox.Items[_itemIndex] = _oldText;

        public void Redo() => Execute();
    }
}