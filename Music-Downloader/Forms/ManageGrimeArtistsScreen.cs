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

namespace Forms
{
	public partial class ManageGrimeArtistsScreen : BaseControl
	{
		public ManageGrimeArtistsScreen()
		{
			InitializeComponent();
		}

		private void ManageGrimeArtistsScreen_Enter(object sender, EventArgs e)
		{
			CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
			CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
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

		}

		private void ButtonAddNewGrimeArtist_Click(object sender, EventArgs e)
		{

		}

		private void ButtonDeleteSelected_Click(object sender, EventArgs e)
		{

		}
	}
}
