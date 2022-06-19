using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Commands;
using Business.Commands.ManageUrlReplacements;
using Business.DTOs;
using Forms.Commands.DownloadMusic;
using Forms.Commands.ManageUrlReplacements;

namespace Forms
{
	public partial class ManageUrlReplacementsScreen : BaseControl
	{
		private IDictionary<string, string> _urlReplacements = new Dictionary<string, string>();
		private string _selectedUrlReplacementKey;

		public ManageUrlReplacementsScreen()
		{
			InitializeComponent();
		}

		private void ManageUrlReplacementsScreen_Enter(object sender, EventArgs e)
		{
			CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
			CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
			SetFormAcceptButton(ButtonAddNewUrlReplacement);
			_urlReplacements = BusinessFacade.Instance.GetUrlReplacements();
			foreach (var (key, value) in _urlReplacements)
			{
				ListBoxUrlReplacements.Items.Add($"\"{key}\" --> \"{value}\"");
			}
			SetWindowMinimumSizeBasedOnTableLayout(tableLayoutPanelMain,false);
			ButtonBack.BringToFront();
		}

		private void ListBoxUrlReplacements_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetSelectedUrlReplacement();
			ButtonDeleteSelected.Enabled = ListBoxUrlReplacements.SelectedItems.Count > 0;
			ButtonDeleteSelected.Visible = ButtonDeleteSelected.Enabled;
		}

		private void GetSelectedUrlReplacement()
		{
			if (ListBoxUrlReplacements.SelectedItems.Count == 0)
			{
				_selectedUrlReplacementKey = null;
				ClearAllTextboxes();
				return;
			}

			_selectedUrlReplacementKey =
				GetUrlReplacementFromString(ListBoxUrlReplacements.Items[ListBoxUrlReplacements.SelectedIndex]
					.ToString());
		}

		private static string GetUrlReplacementFromString(string urlReplacementString)
		{
			var keyWithQuotes = urlReplacementString.Split(" --> ", StringSplitOptions.RemoveEmptyEntries).First();
			return keyWithQuotes.Substring(1, keyWithQuotes.LastIndexOf('"') - 1);
		}

		private void ButtonUndo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Undo();
		}

		private void ButtonRedo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Redo();
		}

		private void ButtonAddChange_Click(object sender, EventArgs e)
		{
			var macro = new MacroCommand();
			var errorMessage = "";
			var whatToReplace = "";
			var replacement = "";
			var errorHappened = false;
			try
			{
				whatToReplace =
					TextBoxWhatToReplace.Text.Substring(1, TextBoxWhatToReplace.Text.LastIndexOf('"') - 1);
			}
			catch (ArgumentOutOfRangeException)
			{
				errorMessage +=
					$@"You need to specify what should be replaced IN BETWEEN QUOTES (""){Environment.NewLine}";
				errorHappened = true;
			}

			try
			{
				replacement =
					TextBoxReplacement.Text.Substring(1, TextBoxReplacement.Text.LastIndexOf('"') - 1);
			}
			catch (ArgumentOutOfRangeException)
			{
				errorMessage += @"You need to specify the replacement IN BETWEEN QUOTES ("")";
				errorHappened = true;
			}

			if (_urlReplacements.ContainsKey(whatToReplace))
			{
				errorHappened = true;
				errorMessage += "You can't specify two different replacements for the same part to replace.";
			}

			if (errorHappened)
			{
				ShowInformationMessageBox(errorMessage, "Error");
				return;
			}

			macro.Add(new CommandAddUrlReplacement(whatToReplace, replacement));
			macro.Add(new CommandAddUrlReplacementToListbox(
				new KeyValuePair<string, string>(whatToReplace, replacement),
				ListBoxUrlReplacements, ref _urlReplacements));
			CommandsManager.Instance.Execute(macro);
		}

		private void ButtonDeleteSelected_Click(object sender, EventArgs e)
		{
			var macro = new MacroCommand();
			macro.Add(new CommandDeleteUrlReplacement(_selectedUrlReplacementKey,ref _urlReplacements));
			macro.Add(new CommandDeleteSelectedListBoxItem(ListBoxUrlReplacements));
			CommandsManager.Instance.Execute(macro);
		}
	}
}