using System.Collections.Generic;
using System.Diagnostics;
using Business.DTOs;
using HtmlAgilityPack;

namespace Business.SongDetailsScrapers
{
    public class GeniusDetailsScraper : SongDetailsTemplateMethod
    {
        public GeniusDetailsScraper(ISet<SongFileDTO> songs, int threadIndex) : base(songs, threadIndex)
        {
        }

        internal override int GetYearOfSingle(SongFileDTO song)
        {
            var htmlDoc = GetHtmlDocFromUrl(GetUrlFromSong(false, song));
            Debug.WriteLine(htmlDoc);
            Debug.WriteLine(htmlDoc.Text);
            throw new System.NotImplementedException();
        }

        internal override int GetYearOfAlbumTrack(SongFileDTO song)
        {
            var htmlDoc = GetHtmlDocFromUrl(GetUrlFromSong(true, song));
            Debug.WriteLine(htmlDoc);
            Debug.WriteLine(htmlDoc.Text);
            throw new System.NotImplementedException();
        }

        internal override string GetLyrics(SongFileDTO song)
        {
            var htmlDoc = GetHtmlDocFromUrl(GetUrlFromSong(false, song));
            Debug.WriteLine(htmlDoc.Text);
            throw new System.NotImplementedException();
        }

        internal override string GetUrlFromSong(bool forAlbumYear, SongFileDTO song)
        {
            if (forAlbumYear)
            {
                return "https://www.genius.com/albums/" + MakeUrlReplacementsOnString(song.AlbumArtist, false) + "/" +
                       MakeUrlReplacementsOnString(song.Album, false);
            }

            return "https://genius.com/" + MakeUrlReplacementsOnString(song.AlbumArtist, false) + "-" +
                   MakeUrlReplacementsOnString(song.Title, true) + "-lyrics";
        }
    }
}