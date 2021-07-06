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
				var item = new ListViewItem(song.Filename);
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.LastModified.ToString("g")));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Title));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.AlbumArtist));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Album));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Genre));
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, song.Year.ToString()));
				ListViewSongFiles.Items.Add(item);
			}
		}

		private void ListViewSongFiles_MouseClick(object sender, MouseEventArgs e)
		{
			var where = ListViewSongFiles.HitTest(e.Location);

			if (where.Location == ListViewHitTestLocations.Label)
			{
				where.Item.Checked = !where.Item.Checked;
			}
		}

		private void ListViewSongFiles_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == _columnSorter.SortColumn)
			{
				_columnSorter.Order = _columnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				_columnSorter.SortColumn = e.Column;
				_columnSorter.Order = SortOrder.Ascending;
			}
			
			ListViewSongFiles.Sort();
		}
	}
}