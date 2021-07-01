using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.DTOs;
using Business.Enums;

namespace Forms
{
    public partial class GetYearAndLyricsScreen : BaseControl
    {
        private IDictionary<SongFileDTO, int> _lineIndexOfSong = new Dictionary<SongFileDTO, int>();
        private int _numberOfFilesDone, _totalNumberOfFiles, _lastWrittenLineIndex;

        private IDictionary<int, KeyValuePair<int, int>> _numberOfFilesDonePerThread =
            new Dictionary<int, KeyValuePair<int, int>>();

        private IDictionary<int, int> _lastUsedLineByThread = new Dictionary<int, int>();

        public object Mutex { get; set; } = new();

        public GetYearAndLyricsScreen()
        {
            InitializeComponent();
            _lastWrittenLineIndex = 0;
        }

        private void GetYearAndLyricsScreen_Enter(object sender, EventArgs e)
        {
            BusinessFacade.Instance.NotifySongFileProgress +=
                (_, args) =>
                {
                    lock (Mutex)
                    {
                        UIChanges(args.Song, args.ThreadId, args.Progress);
                    }
                };

            BusinessFacade.Instance.NotifyInitialThreadsConfiguration += (_, args) =>
                SetupThreadsStatus(args.NumberOfThreads, args.NumberOfFilesPerThread);
            DefaultConfigurations();
            MaximizeWindow();
            BusinessFacade.Instance.OpenService();
            //BusinessFacade.Instance.StartGettingYearAndLyrics();
            Task.Delay(250).ContinueWith(t => BusinessFacade.Instance.StartGettingYearAndLyrics());
        }

        private void UIChanges(SongFileDTO song, int threadId, SongFileProgress progress)
        {
            int line;
            switch (progress)
            {
                case SongFileProgress.GettingYear:
                    line = _lastWrittenLineIndex;
                    _lastWrittenLineIndex++;
                    _lastUsedLineByThread[threadId] = _lastWrittenLineIndex;
                    RichTextBoxArtist.Invoke(new MethodInvoker(delegate
                    {
                        RichTextBoxArtist.AppendText((line > 0 ? Environment.NewLine : "") + song.AlbumArtist);
                        RichTextBoxArtist.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                            RichTextBoxArtist.Lines[line].Length);
                        RichTextBoxArtist.SelectionColor = Color.Yellow;
                        RichTextBoxArtist.ScrollToCaret();
                    }));
                    RichTextBoxAlbum.Invoke(new MethodInvoker(delegate
                    {
                        RichTextBoxAlbum.AppendText((line > 0 ? Environment.NewLine : "") + song.Album);
                        RichTextBoxAlbum.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                            RichTextBoxAlbum.Lines[line].Length);
                        RichTextBoxAlbum.SelectionColor = Color.Yellow;
                        RichTextBoxAlbum.ScrollToCaret();
                    }));
                    RichTextBoxTitle.Invoke(new MethodInvoker(delegate
                    {
                        RichTextBoxTitle.AppendText((line > 0 ? Environment.NewLine : "") + song.Title);
                        RichTextBoxTitle.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                            RichTextBoxTitle.Lines[line].Length);
                        RichTextBoxTitle.SelectionColor = Color.Yellow;
                        RichTextBoxTitle.ScrollToCaret();
                    }));
                    break;
                case SongFileProgress.GettingYearException:
                    break;
                case SongFileProgress.GettingLyrics:
                    ChangeColor(threadId, progress);
                    break;
                case SongFileProgress.GettingLyricsException:
                    break;
                case SongFileProgress.AddingToiTunes:
                    ChangeColor(threadId, progress);
                    break;
                case SongFileProgress.FileDone:
                    ChangeColor(threadId, progress);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(progress), progress, null);
            }
        }

        private void ChangeColor(int threadId, SongFileProgress progress)
        {
            var line = _lastUsedLineByThread[threadId];
            var color = Color.Transparent;
            switch (progress)
            {
                case SongFileProgress.GettingLyrics:
                    color = Color.DarkGreen;
                    break;
                case SongFileProgress.AddingToiTunes:
                    color = Color.Aquamarine;
                    break;
                case SongFileProgress.FileDone:
                    color = Color.LimeGreen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(progress), progress, null);
            }

            RichTextBoxArtist.Invoke(new MethodInvoker(delegate
            {
                RichTextBoxArtist.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                    RichTextBoxArtist.Lines[line].Length);
                RichTextBoxArtist.SelectionColor = color;
            }));
            RichTextBoxAlbum.Invoke(new MethodInvoker(delegate
            {
                RichTextBoxArtist.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                    RichTextBoxArtist.Lines[line].Length);
                RichTextBoxArtist.SelectionColor = color;
            }));
            RichTextBoxAlbum.Invoke(new MethodInvoker(delegate
            {
                RichTextBoxArtist.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
                    RichTextBoxArtist.Lines[line].Length);
                RichTextBoxArtist.SelectionColor = color;
            }));
        }

        private void SetupThreadsStatus(int numberOfThreads, IEnumerable<int> numberOfFilesPerThreadEnumerable)
        {
            _numberOfFilesDone = 0;
            var numberOfFilesPerThread = numberOfFilesPerThreadEnumerable.ToList();
            _totalNumberOfFiles = numberOfFilesPerThread.Sum();
            for (var index = 0; index < numberOfThreads; index++)
            {
                _numberOfFilesDonePerThread.Add(index,
                    new KeyValuePair<int, int>(numberOfFilesPerThread.ElementAt(index), 0));
            }

            TextBoxThreadsStatus.Invoke(
                new MethodInvoker(delegate
                {
                    for (var index = 0; index < numberOfThreads; index++)
                    {
                        TextBoxThreadsStatus.AppendText("Thread " + (index + 1) + Environment.NewLine);
                    }

                    TextBoxThreadsStatus.AppendText(
                        $"All Files: {_numberOfFilesDone}/{_totalNumberOfFiles} Files Processed");
                }));
        }
    }
}