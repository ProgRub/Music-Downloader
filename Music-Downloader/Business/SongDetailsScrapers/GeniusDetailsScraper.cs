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
			HtmlDocument htmlDoc;
			do
			{
				htmlDoc = GetHtmlDocFromUrl(GetUrlFromSong(false));
			} while (!htmlDoc.DocumentNode.Descendants("main").Any());

			HtmlDocumentOfSingle = htmlDoc;
			var htmlNode = htmlDoc.DocumentNode.Descendants("div").Where(e =>
					e.GetAttributeValue("class", "").Contains("HeaderMetadata__Section-sc-1p42fnf-2"))
				.First(e => GetDecodedInnerText(e).Contains("Release"));
			var textSplit = GetDecodedInnerText(htmlNode).Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			return int.Parse(textSplit.Last());
		}

		internal override int GetYearOfAlbumTrack()
		{
			var htmlDoc = GetHtmlDocFromUrl(GetUrlFromSong(true));
			var divs = htmlDoc.DocumentNode.Descendants("div").ToList();
			var textSplit = divs
				.First(e => e.GetAttributeValue("class", "nothing") == "header_with_cover_art-inner column_layout")
				.Descendants().First(e =>
					e.GetAttributeValue("class", "nothing") == "header_with_cover_art-primary_info_container")
				.InnerText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
			return int.Parse(textSplit.Last());
		}

		internal override string GetLyrics()
		{
			HtmlDocument htmlDocument;
			do
			{
				htmlDocument = GetHtmlDocFromUrl(GetUrlFromSong(false));
			} while (!htmlDocument.DocumentNode.Descendants("main").Any());

			var lyrics = "";
			foreach (var htmlNode in htmlDocument.DocumentNode.Descendants("main").First().Descendants("div").Where(e =>
				e.GetAttributeValue("class", "").Contains("Lyrics__Container-sc-1ynbvzw-7 jjqBBp")))
			{
				htmlNode.InnerHtml = htmlNode.InnerHtml.Replace("<br>", Environment.NewLine);
				lyrics += GetDecodedInnerText(htmlNode);
			}

			return lyrics;
		}

		internal override string GetLyrics(HtmlDocument htmlDocument)
		{
			do
			{
				htmlDocument = GetHtmlDocFromUrl(GetUrlFromSong(false));
			} while (!htmlDocument.DocumentNode.Descendants("main").Any());

			var lyrics = "";
			foreach (var htmlNode in htmlDocument.DocumentNode.Descendants("main").First().Descendants("div").Where(e =>
				e.GetAttributeValue("class", "").Contains("Lyrics__Container-sc-1ynbvzw-7 jjqBBp")))
			{
				htmlNode.InnerHtml = htmlNode.InnerHtml.Replace("<br>", Environment.NewLine);
				lyrics += GetDecodedInnerText(htmlNode);
			}

			return lyrics;
		}

		internal override string GetUrlFromSong(bool forAlbumYear)
		{
			if (forAlbumYear)
			{
				return "http://www.genius.com/albums/" + MakeUrlReplacementsOnString(CurrentSong.AlbumArtist, false,false) +
				       "/" +
				       MakeUrlReplacementsOnString(CurrentSong.Album, false,true);
			}

			return "http://genius.com/" + MakeUrlReplacementsOnString(CurrentSong.AlbumArtist, false,false) + "-" +
			       MakeUrlReplacementsOnString(CurrentSong.Title, true,false) + "-lyrics";
		}
	}
}