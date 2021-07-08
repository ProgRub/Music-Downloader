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
using Business.Commands.ManageGrimeArtists;
using Business.Commands.ManageUrlReplacements;
using Forms.Commands.DownloadMusic;
using Forms.Commands.ManageGrimeArtists;

namespace Forms
{
	public partial class ManageGrimeArtistsScreen : BaseControl
	{
		private ICollection<string> _grimeArtists = new List<string>();
		private string _selectedGrimeArtist;

		public ManageGrimeArtistsScreen()
		{
			InitializeComponent();
		}

		private void ManageGrimeArtistsScreen_Enter(object sender, EventArgs e)
		{
			SetFormAcceptButton(ButtonAddNewGrimeArtist);
			CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
			CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
			_grimeArtists = BusinessFacade.Instance.GetGrimeArtists().ToList();
			foreach (var grimeArtist in _grimeArtists)
			{
				ListBoxGrimeArtists.Items.Add(grimeArtist);
			}
		}

		private void ButtonUndo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Undo();
		}

		private void ButtonRedo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Redo();
		}

		private void ListBoxGrimeArtists_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetSelectedGrimeArtist();
			ButtonDeleteSelected.Enabled = ListBoxGrimeArtists.SelectedItems.Count > 0;
			ButtonDeleteSelected.Visible = ButtonDeleteSelected.Enabled;
		}

		private void GetSelectedGrimeArtist()
		{
			if (ListBoxGrimeArtists.SelectedItems.Count == 0)
			{
				_selectedGrimeArtist = null;
				ClearAllTextboxes();
				return;
			}

			_selectedGrimeArtist = ListBoxGrimeArtists.Items[ListBoxGrimeArtists.SelectedIndex].ToString();
		}

		private void ButtonAddNewGrimeArtist_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TextBoxGrimeArtist.Text))
			{
				ShowInformationMessageBox("You can't insert an artist without a name", "Error");
				return;
			}

			var grimeArtist = TextBoxGrimeArtist.Text;
			var macro = new MacroCommand();
			macro.Add(new CommandAddGrimeArtist(grimeArtist));
			macro.Add(new CommandAddGrimeArtistToListBox(grimeArtist, ListBoxGrimeArtists, ref _grimeArtists));
			CommandsManager.Instance.Execute(macro);
		}

		private void ButtonDeleteSelected_Click(object sender, EventArgs e)
		{
			var macro = new MacroCommand();
			macro.Add(new CommandDeleteGrimeArtist(_selectedGrimeArtist));
			macro.Add(new CommandDeleteSelectedListBoxItem(ListBoxGrimeArtists));
			CommandsManager.Instance.Execute(macro);
		}
	}
}