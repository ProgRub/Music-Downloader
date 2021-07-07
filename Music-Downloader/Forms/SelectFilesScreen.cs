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
using Business.DTOs;
using Business.Enums;

namespace Forms
{
	public partial class SelectFilesScreen : BaseControl
	{
		private ISet<SongFileDTO> _songs;
		private ListViewColumnSorter _columnSorter;

		public SelectFilesScreen()
		{
			InitializeComponent();
			_columnSorter = new ListViewColumnSorter();
			ListViewSongFiles.ListViewItemSorter = _columnSorter;
		}

		private void SelectFilesScreen_Enter(object sender, EventArgs e)
		{
			MaximizeWindow();
			_songs = BusinessFacade.Instance.GetAllStoredSongs();
			foreach (var song in _songs)
			{
				var item = new ListViewItem(song.Title);
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.LastModified.ToString("g")));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.AlbumArtist));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Album));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Genre));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Year.ToString()));
				ListViewSongFiles.Items.Add(item);
			}

			foreach (ColumnHeader column in ListViewSongFiles.Columns)
			{
				column.Width = -1;
			}

			var totalWidth = ListViewSongFiles.Columns.Cast<ColumnHeader>().Sum(column => column.Width);

			ListViewSongFiles.Size = new Size(totalWidth + 20, ListViewSongFiles.Size.Height);
			ButtonGetYearAndLyrics.Location =
				new Point(
					ListViewSongFiles.Location.X + ListViewSongFiles.Size.Width - ButtonGetYearAndLyrics.Size.Width,
					ButtonGetYearAndLyrics.Location.Y);
		}

		private void ListViewSongFiles_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == _columnSorter.SortColumn)
			{
				_columnSorter.Order = _columnSorter.Order == SortOrder.Ascending
					? SortOrder.Descending
					: SortOrder.Ascending;
			}
			else
			{
				_columnSorter.SortColumn = e.Column;
				_columnSorter.Order = SortOrder.Ascending;
			}

			ListViewSongFiles.Sort();
		}

		private void ButtonGetYearAndLyrics_Click(object sender, EventArgs e)
		{
			var selectedSongs = new HashSet<SongFileDTO>();
			foreach (int checkedIndex in ListViewSongFiles.CheckedIndices)
			{
				selectedSongs.Add(_songs.First(e =>
					e.Title == ListViewSongFiles.Items[checkedIndex].Text &&
					e.AlbumArtist == ListViewSongFiles.Items[checkedIndex].SubItems[2].Text &&
					e.Album == ListViewSongFiles.Items[checkedIndex].SubItems[3].Text));
			}

			BusinessFacade.Instance.SetGetYearAndLyricsMode(GetYearAndLyricsMode.SelectedFiles);
			BusinessFacade.Instance.SetSelectedFiles(selectedSongs);
			MoveToScreen(new GetYearAndLyricsScreen(), this);
		}

		private void ListViewSongFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			switch (e.IsSelected)
			{
				case true when !ListViewSongFiles.Items[e.ItemIndex].Checked:
					ListViewSongFiles.Items[e.ItemIndex].Checked = true;
					return;
				case true when ListViewSongFiles.Items[e.ItemIndex].Checked:
					ListViewSongFiles.Items[e.ItemIndex].Checked = false;
					break;
			}
		}
	}
}