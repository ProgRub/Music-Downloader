using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.Enums;
using Business.Services;
using DB.Entities;
using HtmlAgilityPack;

namespace Business.SongDetailsScrapers
{
    public abstract class SongDetailsTemplateMethod
    {
        internal event EventHandler<SongFileProgressEventArgs> NotifySongFileProgress;
        private static readonly IDictionary<string, int> _alreadyVisitedAlbumPages = new Dictionary<string, int>();
        private readonly ISet<SongFileDTO> _songs;
        private readonly int _threadIndex;

        private static readonly IEnumerable<KeyValuePair<string, string>> _urlReplacements =
            UrlReplacementService.Instance.GetAllUrlReplacements();

        internal SongDetailsTemplateMethod(ISet<SongFileDTO> songs, int threadIndex)
        {
            _songs = songs;
            _threadIndex = threadIndex;
        }

        internal void GetYearAndLyricsOfSongs()
        {
            foreach (var song in _songs)
            {
                NotifySongFileProgress?.Invoke(this,
                    new SongFileProgressEventArgs
                    {
                        Song = song,
                        ThreadId = _threadIndex,
                        Progress = SongFileProgress.GettingYear
                    });
                if (song.IsSingle)
                {
                    if (DoesWebpageExist(GetUrlFromSong(false, song)))
                    {
                        song.Year = GetYearOfSingle(song);
                        NotifySongFileProgress?.Invoke(this,
                            new SongFileProgressEventArgs
                            {
                                Song = song,
                                ThreadId = _threadIndex,
                                Progress = SongFileProgress.GettingLyrics
                            });
                    }
                    else
                    {
                        NotifySongFileProgress?.Invoke(this,
                            new SongFileProgressEventArgs
                            {
                                Song = song, ThreadId = _threadIndex,
                                Progress = SongFileProgress.GettingYearException
                            });
                    }
                }
                else
                {
                    if (_alreadyVisitedAlbumPages.ContainsKey(song.AlbumArtist + song.Album))
                    {
                        song.Year = _alreadyVisitedAlbumPages[song.AlbumArtist + song.Album];
                    }
                    else
                    {
                        if (DoesWebpageExist(GetUrlFromSong(true, song)))
                        {
                            song.Year = GetYearOfAlbumTrack(song);
                            _alreadyVisitedAlbumPages.Add(song.AlbumArtist + song.Album, song.Year);
                            NotifySongFileProgress?.Invoke(this,
                                new SongFileProgressEventArgs
                                {
                                    Song = song,
                                    ThreadId = _threadIndex,
                                    Progress = SongFileProgress.GettingLyrics
                                });
                        }
                        else
                        {
                            NotifySongFileProgress?.Invoke(this,
                                new SongFileProgressEventArgs
                                {
                                    Song = song,
                                    ThreadId = _threadIndex,
                                    Progress = SongFileProgress.GettingYearException
                                });
                        }
                    }
                }

                if (DoesWebpageExist(GetUrlFromSong(false, song)))
                {
                    GetLyrics(song);
                    NotifySongFileProgress?.Invoke(this,
                        new SongFileProgressEventArgs
                        {
                            Song = song,
                            ThreadId = _threadIndex,
                            Progress = SongFileProgress.AddingToiTunes
                        });
                }
                else
                {
                    NotifySongFileProgress?.Invoke(this,
                        new SongFileProgressEventArgs
                        {
                            Song = song,
                            ThreadId = _threadIndex,
                            Progress = SongFileProgress.GettingLyricsException
                        });
                }

                song.SaveToFile();
                BusinessFacade.Instance.AddSongToService(song);
                NotifySongFileProgress?.Invoke(this,
                    new SongFileProgressEventArgs
                    {
                        Song = song,
                        ThreadId = _threadIndex,
                        Progress = SongFileProgress.FileDone
                    });
            }
        }

        private static bool DoesWebpageExist(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Message.Contains("301"))
                {
                    request = (HttpWebRequest) WebRequest.Create(e.Response.Headers[HttpResponseHeader.Location]);
                    response = (HttpWebResponse) request.GetResponse();
                }
            }

            return response.StatusCode == HttpStatusCode.OK;
        }


        protected static string MakeUrlReplacementsOnString(string detailParameter, bool forSongTitle)
        {
            var detail = detailParameter.ToLower();
            foreach (var (key, value) in _urlReplacements)
            {
                detail = detail.Replace(key, value);
            }

            var auxList = detail.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
            for (var index = 0; index < auxList.Length; index++)
            {
                auxList[index] = auxList[index].Trim();
            }

            detail = string.Join("-", auxList);
            if (!forSongTitle)
            {
                return char.ToUpper(detail[0]) + detail[1..].ToLower();
            }

            return detail.ToLower();
        }

        protected static HtmlDocument GetHtmlDocFromUrl(string url)
        {
            return new HtmlWeb().Load(url);
        }

        internal abstract int GetYearOfSingle(SongFileDTO song);
        internal abstract int GetYearOfAlbumTrack(SongFileDTO song);
        internal abstract string GetLyrics(SongFileDTO song);
        internal abstract string GetUrlFromSong(bool forAlbumYear, SongFileDTO song);
    }
}