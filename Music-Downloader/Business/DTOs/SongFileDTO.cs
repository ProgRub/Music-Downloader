using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Enums;
using Business.Services;

namespace Business.DTOs
{
	public class SongFileDTO
	{
		public string Filename { get; set; }
		public string AlbumArtist { get; set; }
		public IEnumerable<string> ContributingArtists { get; set; }
		public string Album { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public int TrackNumber { get; set; }
		public int TotalTrackCount { get; set; }
		public int DiscNumber { get; set; }
		public int TotalDiscCount { get; set; }
		public int Year { get; set; }
		public string Lyrics { get; set; }

		private static IDictionary<string, string> _genreReplacements = new Dictionary<string, string>
			{{"Alternativa", "Alternative"}};

		public bool IsSingle => TrackNumber == 1 && TotalTrackCount == 1 && DiscNumber == 1 && TotalDiscCount == 1;

		internal static SongFileDTO GetSongFileDTOFromFilePath(string filePath)
		{
			using var songFile = TagLib.File.Create(filePath);
			var albumArtist = songFile.Tag.FirstAlbumArtist;

			string genre;
			if (GrimeArtistService.Instance.GetAllGrimeArtists().Contains(albumArtist))
			{
				genre = "Grime";
			}
			else
			{
				genre = _genreReplacements.ContainsKey(songFile.Tag.FirstGenre)
					? _genreReplacements[songFile.Tag.FirstGenre]
					: songFile.Tag.FirstGenre;
			}

			return new SongFileDTO
			{
				Filename = Path.GetFileName(filePath),
				Album = songFile.Tag.Album,
				AlbumArtist = albumArtist,
				ContributingArtists = songFile.Tag.Performers,
				DiscNumber = (int) songFile.Tag.Disc,
				TrackNumber = (int) songFile.Tag.Track,
				Title = songFile.Tag.Title,
				Genre = genre,
				TotalTrackCount = (int) songFile.Tag.TrackCount,
				TotalDiscCount = (int) songFile.Tag.DiscCount,
				Year = (int) songFile.Tag.Year
			};
		}

		internal void RenameSongFile(RenameFileOptions renameOptions)
		{
			var toAdd = "";
			switch (renameOptions)
			{
				case RenameFileOptions.AddArtist:
				{
					toAdd = " (";
					var artistSplit = AlbumArtist.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();
					if ("The" == artistSplit[0])
					{
						artistSplit.Remove("The");
					}

					if (artistSplit.Count == 1)
					{
						toAdd += artistSplit[0];
					}
					else
					{
						toAdd = artistSplit.Aggregate(toAdd, (current, item) => current + item.ToUpper()[0]);
					}

					toAdd += ").mp3";
					Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					break;
				}
				case RenameFileOptions.AddAlbum:
					toAdd = " (";
					toAdd += Album;
					toAdd += ").mp3";
					Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					break;
				case RenameFileOptions.AddNumber:
					var fileNumber = 2;
					while (File.Exists(Path.Combine(DirectoriesService.Instance.MusicToDirectory, Filename)))
					{
						toAdd = " (" + fileNumber++ + ").mp3";
						Filename = Filename.Substring(0, Filename.LastIndexOf('.')) + toAdd;
					}

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(renameOptions), renameOptions, null);
			}
		}

		public void SaveToFile()
		{
			SongService.Instance.SetYearAndLyricsOfSongByFilename(Filename, Year, Lyrics);
			using var songFile =
				TagLib.File.Create(Path.Combine(DirectoriesService.Instance.MusicToDirectory, Filename));
			songFile.Tag.Lyrics = Lyrics;
			songFile.Tag.Year = (uint) Year;
			songFile.Tag.Genres = new[] {Genre};
			songFile.Tag.AlbumArtists = new[] {AlbumArtist};
			songFile.Save();
		}

		internal SongFileDTO Copy()
		{
			return new()
			{
				Filename = Filename,
				AlbumArtist = AlbumArtist,
				Album = Album,
				Title = Title,
				ContributingArtists = ContributingArtists,
				Genre = Genre,
				Lyrics = Lyrics,
				TrackNumber = TrackNumber,
				TotalTrackCount = TotalTrackCount,
				DiscNumber = DiscNumber,
				TotalDiscCount = TotalDiscCount
			};
		}
	}
}