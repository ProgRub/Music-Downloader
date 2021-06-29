using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Commands;
using Business.Commands.DownloadMusic;

namespace Forms
{
    public partial class DownloadMusicScreen : BaseControl
    {
        public DownloadMusicScreen()
        {
            InitializeComponent();
        }

        private void DownloadMusicScreen_Enter(object sender, EventArgs e)
        {
            CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
            CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
            DefaultConfigurations();
            SetFormAcceptButton(ButtonMoveFilesGetLyrics);
        }

        private void ListBoxBeforeFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete || ListBoxBeforeFiles.SelectedItem == null) return;
            var macroCommand = new MacroCommand();
            //macroCommand.Add(new CommandDeleteFile());
            macroCommand.Add(new CommandDeleteSelectedListBoxItem(ListBoxBeforeFiles));
            CommandsManager.Instance.Execute(macroCommand);
        }

        private void ButtonMoveFilesGetLyrics_Click(object sender, EventArgs e)
        {
            var button = (Button) sender;
            if (button.Text != "Move Files") return;
            button.Text = "Get Lyrics And Year";
            button.Location = new Point(button.Location.X - 20, button.Location.Y);
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            CommandsManager.Instance.Undo();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            CommandsManager.Instance.Redo();
        }

        private void ButtonRenameFile_Click(object sender, EventArgs e)
        {
            if(ListBoxBeforeFiles.SelectedItem == null) return;
            var macroCommand = new MacroCommand();
            //macroCommand.Add(new CommandRenameFile());
            macroCommand.Add(new CommandRenameSelectedListBoxItem(TextBoxRenameFile.Text,ListBoxBeforeFiles));
            CommandsManager.Instance.Execute(macroCommand);
            ListBoxBeforeFiles.SelectedItem = null;
        }

        private void ListBoxBeforeFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxBeforeFiles.SelectedIndex > -1)
            {
                TextBoxRenameFile.Text = ListBoxBeforeFiles.SelectedItem.ToString();
                TextBoxRenameFile.Enabled = true;
                TextBoxRenameFile.Focus();
                TextBoxRenameFile.SelectionStart = TextBoxRenameFile.Text.Length;
                SetFormAcceptButton(ButtonRenameFile);
            }
            else
            {
                ClearTextBox(TextBoxRenameFile);
                TextBoxRenameFile.Enabled = false;
                SetFormAcceptButton(ButtonMoveFilesGetLyrics);
            }
        }
    }
}