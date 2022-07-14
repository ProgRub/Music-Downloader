using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Business.DTOs;
using HtmlAgilityPack;

namespace Business.SongDetailsScrapers
{
	public class GeniusDetailsScraper : SongDetailsTemplateMethod
	{
		public GeniusDetailsScraper(ISet<SongFileDTO> songs, int threadId) : base(songs, threadId)
		{
		}

		internal override int GetYearOfSingle()
		{
			return CachedHtmlDocument.DocumentNode.Descendants("main").Any()
				? GetYearOfSingleVersion1()
				: GetYearOfSingleVersion2();
		}

		private int GetYearOfSingleVersion1()
		{
			var htmlNode = CachedHtmlDocument.DocumentNode.Descendants("div").Where(e =>
					e.GetAttributeValue("class", "").Contains("HeaderMetadata__Section-sc-1p42fnf"))
				.First(e => GetDecodedInnerText(e).Contains("Release"));
			var textSplit = GetDecodedInnerText(htmlNode).Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			return int.Parse(textSplit.Last());
		}

		private int GetYearOfSingleVersion2()
		{
			foreach (var htmlNode in CachedHtmlDocument.DocumentNode.Descendants("div").Where(e=>e.GetAttributeValue("class","")=="metadata_unit metadata_unit--table_row"))
			{
				var innerTextSplit = GetDecodedInnerText(htmlNode).Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
				if (innerTextSplit[0].Contains("Release"))
				{
					return int.Parse(innerTextSplit.Last());
				}
			}
			throw new FormatException();
		}
		internal override int GetYearOfAlbumTrack()
		{
			var divs = CachedHtmlDocument.DocumentNode.Descendants("div").ToList();
			var textSplit = divs
				.First(e => e.GetAttributeValue("class", "nothing") == "header_with_cover_art-inner column_layout")
				.Descendants().First(e =>
					e.GetAttributeValue("class", "nothing") == "header_with_cover_art-primary_info_container")
				.InnerText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			return int.Parse(textSplit.Last());
		}

		internal override string GetLyrics()
		{
			return CachedHtmlDocument.DocumentNode.Descendants("main").Any()
				? GetLyricsVersion1()
				: GetLyricsVersion2();
		}

		private string GetLyricsVersion1()
		{
			var lyrics = "";
			foreach (var htmlNode in CachedHtmlDocument.DocumentNode.Descendants("main").First().Descendants("div")
				.Where(e =>
					e.GetAttributeValue("class", "").Contains("Lyrics__Container-sc-1ynbvzw")))
			{
				htmlNode.InnerHtml = htmlNode.InnerHtml.Replace("<br>", Environment.NewLine).Replace("</div></div>", Environment.NewLine)
					.Replace("<inread-ad></inread-ad>", Environment.NewLine);
				lyrics += GetDecodedInnerText(htmlNode);
				lyrics += Environment.NewLine;
			}

			lyrics = lyrics.Trim();
			if (string.IsNullOrWhiteSpace(lyrics)) lyrics = "[Instrumental]";
			return lyrics;
		}

		private string GetLyricsVersion2()
		{
			var lyrics = "";
			foreach (var div in CachedHtmlDocument.DocumentNode
				.Descendants("div").First(e => e.GetAttributeValue("class", "") == "song_body column_layout")
				.Descendants())
			{
				if (div.GetAttributeValue("class", "") != "lyrics") continue;
				var htmlNode = div;
				lyrics += GetDecodedInnerText(htmlNode);
				break;
			}

			lyrics = lyrics.Replace("\n", Environment.NewLine).Trim();
			if (lyrics is "(Instrumental)" or "[instrumental]") lyrics = "[Instrumental]";
			return lyrics;
		}

		internal override string GetUrlFromSong(bool forAlbumYear)
		{
			if (forAlbumYear)
			{
				return "https://genius.com/albums/" +
				       MakeUrlReplacementsOnString(CurrentSong.AlbumArtist, false, false) +
				       "/" +
				       MakeUrlReplacementsOnString(CurrentSong.Album, false, true);
			}

			return "https://genius.com/" + MakeUrlReplacementsOnString(CurrentSong.AlbumArtist, false, false) + "-" +
			       MakeUrlReplacementsOnString(CurrentSong.Title, true, false) + "-lyrics";
		}
	}
}