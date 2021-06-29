using System.Collections.Generic;

namespace Business.DTOs
{
    public class SongFileDTO
    {
        public string Filename { get; set; }
        public string AlbumArtist { get; set; }
        public IEnumerable<string> ContributingArtists { get; set; }
        public string Album { get; set; }
        public string SongTitle { get; set; }
        public string Genre { get; set; }
        public int TrackNumber { get; set; }
        public int TotalTrackCount { get; set; }
        public int DiscNumber { get; set; }
        public int TotalDiscCount { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }
    }
}