using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Business.DTOs;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class SongService
	{
		private readonly ISongRepository _songRepository;

		private ICollection<SongFileDTO> _addedSongs;

		private SongService()
		{
			_songRepository = new SongRepository(Database.GetContext());
			_addedSongs = new List<SongFileDTO>();
		}

		internal static SongService Instance { get; } = new();

		internal void AddSong(SongFileDTO song)
		{
			if (_songRepository.Find(e => e.Filename == song.Filename).Any())
			{
				ModifySong(song);
				return;
			}

			_addedSongs.Add(song);
		}

		internal bool IsInDatabase(SongFileDTO song) =>
			_songRepository.Find(e => e.Filename == song.Filename).Any();

		private void ModifySong(SongFileDTO song)
		{
			var songInDB = _songRepository.Find(e => e.Filename == song.Filename).First();
			songInDB.ContributingArtists = song.ContributingArtists.ToList();
			songInDB.TrackNumber = song.TrackNumber;
			songInDB.DiscNumber = song.DiscNumber;
			songInDB.Duration = song.Duration;
			songInDB.AlbumArtist = song.AlbumArtist;
			songInDB.Year = song.Year;
			songInDB.Title = song.Title;
			songInDB.LastModified =
				File.GetLastWriteTime(Path.Combine(DirectoriesService.Instance.MusicToDirectory, song.Filename));
		}

		internal void RemoveSingle(SongFileDTO albumTrack)
		{
			var songDB = _songRepository.Find(e => e.Filename == albumTrack.Filename).First();
			_songRepository.RemoveSingle(songDB);
		}

		internal void SetYearAndLyricsOfSong(SongFileDTO song, int year, string lyrics)
		{
			try
			{
				var songInDB = _songRepository.Find(e => e.Filename == song.Filename).First();
				ModifySong(song);

				songInDB.Year = year;
				songInDB.Lyrics = lyrics;
			}
			catch (InvalidOperationException)
			{
				AddSong(song);
			}
		}

		internal void SaveChanges()
		{
			foreach (var addedSong in _addedSongs)
			{
				var song = new Song
				{
					Filename = addedSong.Filename, ContributingArtists = addedSong.ContributingArtists.ToList(),
					PlayCount = 0,
					Year = addedSong.Year,
					TrackNumber = addedSong.TrackNumber, DiscNumber = addedSong.DiscNumber, Title = addedSong.Title,
					AlbumArtist = addedSong.AlbumArtist, Duration = addedSong.Duration,Lyrics = addedSong.Lyrics
				};
				_songRepository.Add(song,addedSong.Album,addedSong.Genre,addedSong.TotalTrackCount,addedSong.TotalDiscCount,File.GetLastWriteTime(Path.Combine(DirectoriesService.Instance.MusicToDirectory,song.Filename)));
			}

			_songRepository.SaveChanges();
		}
	}
}