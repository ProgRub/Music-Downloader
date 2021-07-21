using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Commands;
using Business.Enums;

namespace Forms
{
	public partial class HomeScreen : BaseControl
	{
		private string _musicFromDirectory, _musicToDirectory;

		public HomeScreen()
		{
			InitializeComponent();
		}

		private void ButtonDownloadMusic_Click(object sender, EventArgs e)
		{
			MoveToScreen(new DownloadMusicScreen(), this);
		}

		private void ButtonChooseMusicFromDirectory_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog.Description = "Pick the folder where the music gets downloaded to";
			var dialogResult = FolderBrowserDialog.ShowDialog();

			if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath)) return;
			_musicFromDirectory = FolderBrowserDialog.SelectedPath;
			TextBoxMusicFromDirectory.Text = _musicFromDirectory;
			BusinessFacade.Instance.SetMusicFromDirectory(_musicFromDirectory);
		}

		private void ButtonChooseMusicToDirectory_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog.Description = "Pick the folder where you store your music";
			var dialogResult = FolderBrowserDialog.ShowDialog();

			if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath)) return;
			_musicToDirectory = FolderBrowserDialog.SelectedPath;
			TextBoxMusicToDirectory.Text = _musicToDirectory;
			BusinessFacade.Instance.SetMusicToDirectory(_musicToDirectory);
		}

		private void ButtonManageExceptions_Click(object sender, EventArgs e)
		{
			MoveToScreen(new ManageExceptionsScreen(),this);
		}

		private void ButtonManageUrlReplacements_Click(object sender, EventArgs e)
		{
			MoveToScreen(new ManageUrlReplacementsScreen(),this);
		}

		private void ButtonManageGrimeArtists_Click(object sender, EventArgs e)
		{
			MoveToScreen(new ManageGrimeArtistsScreen(),this);
		}

		private void ButtonAllFilesYearAndLyrics_Click(object sender, EventArgs e)
		{
			BusinessFacade.Instance.SetGetYearAndLyricsMode(GetYearAndLyricsMode.AllFiles);
			MoveToScreen(new GetYearAndLyricsScreen(),this);
		}

		private void ButtonSelectFiles_Click(object sender, EventArgs e)
		{
			MoveToScreen(new SelectFilesScreen(),this);
		}

		private void HomeScreen_Enter(object sender, EventArgs e)
		{
			CommandsManager.Instance.ResetCommandsList();
			BusinessFacade.Instance.SaveChanges();
			_musicFromDirectory = BusinessFacade.Instance.GetMusicFromDirectory();
			_musicToDirectory = BusinessFacade.Instance.GetMusicToDirectory();
			TextBoxMusicFromDirectory.Text = _musicFromDirectory;
			TextBoxMusicToDirectory.Text = _musicToDirectory;
		}
	}
}