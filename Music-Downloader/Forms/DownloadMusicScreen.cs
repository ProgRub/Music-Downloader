using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Commands;
using Business.Commands.DownloadMusic;
using Business.CustomEventArgs;
using Business.Enums;
using Forms.Commands.DownloadMusic;

namespace Forms
{
	public partial class DownloadMusicScreen : BaseControl
	{
		private int _numberOfFiles;

		public DownloadMusicScreen()
		{
			InitializeComponent();
			_numberOfFiles = 0;
		}

		private void DownloadMusicScreen_Enter(object sender, EventArgs e)
		{
			CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
			CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
			BusinessFacade.Instance.NotifyNewDownloadedMusicFile += (_, args) =>
			{
				ListBoxBeforeFiles.Invoke(
					new MethodInvoker(delegate { ListBoxBeforeFiles.Items.Add(args.Filename); }));
				LabelNumberOfFiles.Invoke(
					new MethodInvoker(delegate { LabelNumberOfFiles.Text = $"{++_numberOfFiles} Files Found"; }));
			};
			BusinessFacade.Instance.NotifyMusicFileMoved += (_, args) =>
			{
				LabelNumberOfFiles.Invoke(
					new MethodInvoker(delegate { LabelNumberOfFiles.Text = $"{++_numberOfFiles} Files Moved"; }));
				var newLine = args.Filename;
				switch (args.Condition)
				{
					case FileMovedCondition.NoProblem:
						break;
					case FileMovedCondition.ReplacedSingle:
						newLine += " SINGLE REPLACED";
						break;
					case FileMovedCondition.AlreadyExists:
						newLine += " already exists, DELETED";
						break;
					case FileMovedCondition.HadToBeRenamed:
						newLine += " had to be RENAMED";
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				newLine += Environment.NewLine;
				TextBoxAfterFiles.Invoke(
					new MethodInvoker(delegate { TextBoxAfterFiles.AppendText(newLine); }));
			};
			BusinessFacade.Instance.StartDeemix();
			BusinessFacade.Instance.GetDownloadedMusicFiles();
			SetFormAcceptButton(ButtonMoveFilesGetLyrics);
			SetWindowMinimumSizeBasedOnTableLayout(tableLayoutPanelMain,true);
		}

		private void ListBoxBeforeFiles_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Delete || ListBoxBeforeFiles.SelectedItem == null) return;
			var macroCommand = new MacroCommand();
			macroCommand.Add(new CommandDeleteFile(ListBoxBeforeFiles.SelectedItem.ToString()));
			macroCommand.Add(new CommandDeleteSelectedListBoxItem(ListBoxBeforeFiles));
			CommandsManager.Instance.Execute(macroCommand);
		}

		private void ButtonMoveFilesGetLyrics_Click(object sender, EventArgs e)
		{
			var button = (Button) sender;
			if (button.Text != "Move Files")
			{
				BusinessFacade.Instance.SetGetYearAndLyricsMode(GetYearAndLyricsMode.DownloadedFiles);
				MoveToScreen(new GetYearAndLyricsScreen(), this);
				return;
			}

			BusinessFacade.Instance.KillDeemix();
			_numberOfFiles = 0;
			LabelNumberOfFiles.Text = $"{_numberOfFiles} Files Moved";
			BusinessFacade.Instance.MoveFiles();
			button.Text = "Get Lyrics And Year";
			button.Location = new Point(button.Location.X - 25, button.Location.Y);
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
			if (ListBoxBeforeFiles.SelectedItem == null) return;
			var macroCommand = new MacroCommand();
			macroCommand.Add(new CommandRenameFile(ListBoxBeforeFiles.SelectedItem.ToString(), TextBoxRenameFile.Text));
			macroCommand.Add(new CommandRenameSelectedListBoxItem(TextBoxRenameFile.Text, ListBoxBeforeFiles));
			CommandsManager.Instance.Execute(macroCommand);
			ListBoxBeforeFiles.SelectedItem = null;
			SetFormAcceptButton(ButtonMoveFilesGetLyrics);
		}

		private void ListBoxBeforeFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ListBoxBeforeFiles.SelectedIndex > -1)
			{
				TextBoxRenameFile.Text = ListBoxBeforeFiles.SelectedItem.ToString();
				TextBoxRenameFile.Enabled = true;
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