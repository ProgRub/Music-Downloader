using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public bool IsSingle => TrackNumber == 1 && TotalTrackCount == 1 && DiscNumber == 1 && TotalDiscCount == 1;

        internal static SongFileDTO GetSongFileDTOFromFilePath(string filePath)
        {
            using var songFile = TagLib.File.Create(filePath);
            return new SongFileDTO
            {
                Filename = Path.GetFileName(filePath),
                Album = songFile.Tag.Album,
                AlbumArtist = songFile.Tag.FirstAlbumArtist,
                ContributingArtists = songFile.Tag.Performers,
                DiscNumber = (int) songFile.Tag.Disc,
                TrackNumber = (int) songFile.Tag.Track,
                Title = songFile.Tag.Title,
                Genre = songFile.Tag.FirstGenre,
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
            }
        }

        public void SaveToFile()
        {
            using var songFile =
                TagLib.File.Create(Path.Combine(DirectoriesService.Instance.MusicToDirectory, Filename));
            songFile.Tag.Lyrics = Lyrics;
            songFile.Tag.Year = (uint) Year;
            songFile.Save();
        }
    }

    public enum RenameFileOptions
    {
        AddAlbum,
        AddArtist,
        AddNumber
    }
}