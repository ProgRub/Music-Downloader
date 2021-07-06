using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		private ICollection<Song> _addedSongs;

		private SongService()
		{
			_songRepository = new SongRepository(Database.GetContext());
			_addedSongs = new List<Song>();
		}

		internal static SongService Instance { get; } = new();

		internal void AddSong(SongFileDTO song)
		{
			if(_songRepository.Find(e=>e.Filename==song.Filename).Any()) return;
			var songDB = new Song
			{
				Filename = song.Filename, ContributingArtists = song.ContributingArtists.ToList(), PlayCount = 0,
				Year = song.Year,
				TrackNumber = song.TrackNumber, DiscNumber = song.DiscNumber, Title = song.Title,
				AlbumArtist = song.AlbumArtist
			};
			_addedSongs.Add(songDB);
			_songRepository.Add(songDB, song.Album, song.Genre, song.TotalTrackCount, song.TotalDiscCount);
		}

		internal void ChangeSingleInformation(SongFileDTO albumTrack)
		{
			var songDB = _songRepository.Find(e => e.Filename == albumTrack.Filename).First();
			_songRepository.RemoveSingle(songDB);
			AddSong(albumTrack);
		}

		internal void SetYearAndLyricsOfSong(SongFileDTO song, int year, string lyrics)
		{
			Song songInDB;
			try
			{
				songInDB = _songRepository.Find(e=>e.Filename==song.Filename).First();
			}
			catch (InvalidOperationException)
			{
				AddSong(song);
				songInDB = _addedSongs.First(e => e.Filename == song.Filename);
			}

			songInDB.Year = year;
			songInDB.Lyrics = lyrics;
		}

		internal void SaveChanges() => _songRepository.SaveChanges();
	}
}