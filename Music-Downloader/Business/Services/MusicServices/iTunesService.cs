using System;
using System.IO;
using Business.DTOs;
using iTunesLib;

namespace Business.Services.MusicServices
{
	public class iTunesService : IMusicService
	{
		private iTunesService()
		{
		}

		private iTunesApp _iTunes;
		private IITLibraryPlaylist _iTunesLibrary;

		public static IMusicService Instance { get; } = new iTunesService();

		public void AddSong(SongFileDTO song)
		{

			var operationStatus=_iTunesLibrary.AddFile(Path.Combine(DirectoriesService.Instance.MusicToDirectory, song.Filename));
			while (operationStatus.InProgress) { }
			var addedTrack = operationStatus.Tracks[1];
			if (song.Year < 1985)
			{
				addedTrack.VolumeAdjustment = 50;
			}
		}

		public void DeleteSong(SongFileDTO song)
		{
			GetTrack(song.Title,song.Album).Delete();
		}

		public int GetPlayCountOfSong(SongFileDTO song)
		{
			return GetTrack(song.Title, song.Album).PlayedCount;
		}

		private IITTrack GetTrack(string title, string album)
		{
			if (_iTunes == null)
			{
				OpenService();
			}
			var tracks = _iTunesLibrary.Search(title, ITPlaylistSearchField.ITPlaylistSearchFieldSongNames);
			if (tracks == null) return null;
			for (var index = 1; index <= tracks.Count; index++)
			{
				if (tracks[index].Album == album)
				{
					return tracks[index];
				}
			}

			return null;
		}

		public void OpenService()
		{
			if(_iTunes!=null)return;
			_iTunes = new iTunesApp();
			_iTunesLibrary = _iTunes.LibraryPlaylist;
		}

		public void EndLink()
		{
			if (_iTunes == null) return;
			System.Runtime.InteropServices.Marshal.ReleaseComObject(_iTunes);
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}