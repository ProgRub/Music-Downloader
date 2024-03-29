﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.Enums;

namespace Forms
{
	public partial class GetYearAndLyricsScreen : BaseControl
	{
		private int _numberOfFilesDone, _totalNumberOfFiles, _lastWrittenLineIndex;

		private readonly IDictionary<int, int> _numberOfFilesDonePerThread =
			new Dictionary<int, int>();

		private readonly IDictionary<int, int> _numberOfTotalFilesPerThread =
			new Dictionary<int, int>();

		private readonly IDictionary<int, int> _lastUsedLineByThread = new Dictionary<int, int>();
		private readonly Stopwatch _timeElapsed;
		private readonly Timer _clock;
		private SongFileDTO _errorSong;
		private SongFileProgress _typeOfException;
		private int _threadIdWithError;

		public object UIChangesMutex { get; set; } = new();

		public GetYearAndLyricsScreen()
		{
			InitializeComponent();
			var buddies = new Control[]
			{
				SyncRichTextBoxAlbum, SyncRichTextBoxTitle,SyncRichTextBoxThreadIdStartEndTimes
			};
			SyncRichTextBoxArtist.Buddies = buddies;
			buddies = new Control[]
			{
				SyncRichTextBoxArtist, SyncRichTextBoxTitle,SyncRichTextBoxThreadIdStartEndTimes
			};
			SyncRichTextBoxAlbum.Buddies = buddies;
			buddies = new Control[]
			{
				SyncRichTextBoxAlbum, SyncRichTextBoxArtist,SyncRichTextBoxThreadIdStartEndTimes
			};
			SyncRichTextBoxTitle.Buddies = buddies;
			buddies = new Control[]
			{
				SyncRichTextBoxArtist,SyncRichTextBoxAlbum,SyncRichTextBoxTitle
			};
			SyncRichTextBoxThreadIdStartEndTimes.Buddies = buddies;
			_lastWrittenLineIndex = 0;
			_timeElapsed = new Stopwatch();
			_clock = new Timer
			{
				Interval = 1000
			};
			_clock.Tick += Clock_Tick;
			_timeElapsed.Start();
			_clock.Start();
		}

		private void GetYearAndLyricsScreen_Enter(object sender, EventArgs e)
		{
			BusinessFacade.Instance.NotifySongFileProgress +=
				(_, args) =>
				{
					lock (UIChangesMutex)
					{
						UIChanges(args);
					}
				};

			BusinessFacade.Instance.NotifyInitialThreadsConfiguration += (_, args) =>
				SetupThreadsStatus(args.NumberOfThreads, args.NumberOfFilesPerThread);
			MaximizeWindow();
			SetFormAcceptButton(ButtonTryAgain);
			BusinessFacade.Instance.OpenService();
			BusinessFacade.Instance.StartGettingYearAndLyrics();
			SetWindowMinimumSizeBasedOnTableLayout(tableLayoutPanelMain,true);
		}

		private void Clock_Tick(object sender, EventArgs e)
		{
			var elapsedTime = _timeElapsed.Elapsed;
			LabelTimeElapsed.Text =
				$"Time Elapsed: {elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
		}

		private void UIChanges(SongFileProgressEventArgs eventArgs)
		{
			switch (eventArgs.Progress)
			{
				case SongFileProgress.GettingYear:
					AddSongInformationToTextBoxes(eventArgs);
					break;
				case SongFileProgress.GettingYearException:
					SystemSounds.Exclamation.Play();
					LabelUrl.Invoke(new MethodInvoker(delegate { LabelUrl.Text = eventArgs.Url; }));
					ActivateCorrectionControls(eventArgs);
					_threadIdWithError = eventArgs.ThreadId;
					break;
				case SongFileProgress.GettingLyrics:
					ChangeColorOfLastUsedLineByThread(eventArgs);
					break;
				case SongFileProgress.GettingLyricsException:
					SystemSounds.Exclamation.Play();
					LabelUrl.Invoke(new MethodInvoker(delegate { LabelUrl.Text = eventArgs.Url; }));
					ActivateCorrectionControls(eventArgs);
					_threadIdWithError = eventArgs.ThreadId;
					break;
				case SongFileProgress.AddingToService:
					ChangeColorOfLastUsedLineByThread(eventArgs);
					break;
				case SongFileProgress.FileDone:
					FileDoneUpdateThreadsStatus(eventArgs);
					ChangeColorOfLastUsedLineByThread(eventArgs);
					if (_numberOfFilesDone == _totalNumberOfFiles)
					{
						AllFilesFinishedUIChanges();
					}

					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(eventArgs.Progress), eventArgs.Progress, null);
			}
		}

		private void FileDoneUpdateThreadsStatus(SongFileProgressEventArgs eventArgs)
		{
			_numberOfFilesDone++;
			_numberOfFilesDonePerThread[eventArgs.ThreadId]++;
			TextBoxThreadsStatus.Invoke(
				new MethodInvoker(delegate
				{
					TextBoxThreadsStatus.Select(
						TextBoxThreadsStatus.GetFirstCharIndexFromLine(eventArgs.ThreadId),
						TextBoxThreadsStatus.Lines[eventArgs.ThreadId].Length);
					var totalFilesOfThread = _numberOfTotalFilesPerThread[eventArgs.ThreadId];
					var filesDoneByThread = _numberOfFilesDonePerThread[eventArgs.ThreadId];
					TextBoxThreadsStatus.SelectedText =
						$"Thread {eventArgs.ThreadId + 1}: {filesDoneByThread}/{totalFilesOfThread} Files Processed {(filesDoneByThread == totalFilesOfThread ? "All Done!" : "")}";
					TextBoxThreadsStatus.Select(
						TextBoxThreadsStatus.GetFirstCharIndexFromLine(_lastUsedLineByThread.Count),
						TextBoxThreadsStatus.Lines[_lastUsedLineByThread.Count].Length);
					TextBoxThreadsStatus.SelectedText =
						$"All Files: {_numberOfFilesDone}/{_totalNumberOfFiles} Files Processed";
				}));
			SyncRichTextBoxThreadIdStartEndTimes.Invoke(new MethodInvoker(delegate
			{
				var line = _lastUsedLineByThread[eventArgs.ThreadId];
				var elapsedTime = _timeElapsed.Elapsed;
				SyncRichTextBoxThreadIdStartEndTimes.Select(
					SyncRichTextBoxThreadIdStartEndTimes.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxThreadIdStartEndTimes.Lines[line].Length);
				SyncRichTextBoxThreadIdStartEndTimes.SelectedText +=
					$"|{elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
			}));
		}

		private void AddSongInformationToTextBoxes(SongFileProgressEventArgs eventArgs)
		{
			var line = _lastWrittenLineIndex;
			_lastUsedLineByThread[eventArgs.ThreadId] = _lastWrittenLineIndex++;
			SyncRichTextBoxArtist.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxArtist.AppendText((line > 0 ? Environment.NewLine : "") +
				                                 eventArgs.Song.AlbumArtist);
				SyncRichTextBoxArtist.Select(SyncRichTextBoxArtist.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxArtist.Lines[line].Length);
				SyncRichTextBoxArtist.SelectionColor = SyncRichTextBoxArtist.ForeColor;
				if (CheckBoxScrollToEnd.Checked)
					SyncRichTextBoxArtist.ScrollToCaret();
			}));
			SyncRichTextBoxAlbum.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxAlbum.AppendText((line > 0 ? Environment.NewLine : "") + eventArgs.Song.Album);
				SyncRichTextBoxAlbum.Select(SyncRichTextBoxAlbum.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxAlbum.Lines[line].Length);
				SyncRichTextBoxAlbum.SelectionColor = SyncRichTextBoxAlbum.ForeColor;
				if (CheckBoxScrollToEnd.Checked)
					SyncRichTextBoxAlbum.ScrollToCaret();
			}));
			SyncRichTextBoxTitle.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxTitle.AppendText((line > 0 ? Environment.NewLine : "") + eventArgs.Song.Title);
				SyncRichTextBoxTitle.Select(SyncRichTextBoxTitle.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxTitle.Lines[line].Length);
				SyncRichTextBoxTitle.SelectionColor = SyncRichTextBoxTitle.ForeColor;
				if (CheckBoxScrollToEnd.Checked)
					SyncRichTextBoxTitle.ScrollToCaret();
			}));
			SyncRichTextBoxThreadIdStartEndTimes.Invoke(new MethodInvoker(delegate
			{
				var elapsedTime = _timeElapsed.Elapsed;
				SyncRichTextBoxThreadIdStartEndTimes.AppendText((line > 0 ? Environment.NewLine : "") + $"{eventArgs.ThreadId+1}|{elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}");
				if (CheckBoxScrollToEnd.Checked)
					SyncRichTextBoxThreadIdStartEndTimes.ScrollToCaret();
			}));
		}

		private void ActivateCorrectionControls(SongFileProgressEventArgs eventArgs)
		{
			_errorSong = eventArgs.Song;
			_typeOfException = eventArgs.Progress;
			switch (_typeOfException)
			{
				case SongFileProgress.GettingYearException:
					if (_errorSong.IsSingle)
					{
						TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate
						{
							TextBoxCorrectArtist.Enabled = true;
							TextBoxCorrectArtist.Text = _errorSong.AlbumArtist;
							TextBoxCorrectArtist.Focus();
						}));
						TextBoxCorrectTitle.Invoke(
							new MethodInvoker(delegate
							{
								TextBoxCorrectTitle.Enabled = true;
								TextBoxCorrectTitle.Text = _errorSong.Title;
							}));
						ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Enabled = true; }));
						ButtonSkipLyrics.Invoke(new MethodInvoker(delegate { ButtonSkipLyrics.Enabled = true; }));
					}
					else
					{
						TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate
						{
							TextBoxCorrectArtist.Enabled = true;
							TextBoxCorrectArtist.Text = _errorSong.AlbumArtist;
							TextBoxCorrectArtist.Focus();
						}));
						TextBoxCorrectAlbum.Invoke(
							new MethodInvoker(delegate
							{
								TextBoxCorrectAlbum.Enabled = true;
								TextBoxCorrectAlbum.Text = _errorSong.Album;
							}));
						ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Enabled = true; }));
						ButtonSkipYear.Invoke(new MethodInvoker(delegate { ButtonSkipYear.Enabled = true; }));
					}

					break;
				case SongFileProgress.GettingLyricsException:
					TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate
					{
						TextBoxCorrectArtist.Enabled = true;
						TextBoxCorrectArtist.Text = _errorSong.AlbumArtist;
						TextBoxCorrectArtist.Focus();
					}));
					TextBoxCorrectTitle.Invoke(new MethodInvoker(delegate
					{
						TextBoxCorrectTitle.Enabled = true;
						TextBoxCorrectTitle.Text = _errorSong.Title;
					}));
					ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Enabled = true; }));
					ButtonSkipLyrics.Invoke(new MethodInvoker(delegate { ButtonSkipLyrics.Enabled = true; }));
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(_typeOfException), _typeOfException, null);
			}
		}

		private void DeactivateCorrectionControls()
		{
			TextBoxCorrectAlbum.Invoke(new MethodInvoker(delegate
			{
				TextBoxCorrectAlbum.Enabled = false;
				ClearTextBox(TextBoxCorrectAlbum);
			}));
			TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate
			{
				TextBoxCorrectArtist.Enabled = false;
				ClearTextBox(TextBoxCorrectArtist);
			}));
			TextBoxCorrectTitle.Invoke(new MethodInvoker(delegate
			{
				TextBoxCorrectTitle.Enabled = false;
				ClearTextBox(TextBoxCorrectTitle);
			}));
			LabelUrl.Invoke(new MethodInvoker(delegate { LabelUrl.Text = "Genius URL"; }));
			ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Enabled = false; }));
			ButtonSkipLyrics.Invoke(new MethodInvoker(delegate { ButtonSkipLyrics.Enabled = false; }));
			ButtonSkipYear.Invoke(new MethodInvoker(delegate { ButtonSkipYear.Enabled = false; }));
		}

		private void AllFilesFinishedUIChanges()
		{
			_clock.Stop();
			_timeElapsed.Stop();
			LabelTimeElapsed.Invoke(new MethodInvoker(delegate
			{
				LabelTimeElapsed.Text =
					$"All Done! Time Elapsed: {_timeElapsed.Elapsed.Hours:00}:{_timeElapsed.Elapsed.Minutes:00}:{_timeElapsed.Elapsed.Seconds:00}";
			}));
			LabelUrl.Invoke(new MethodInvoker(delegate { LabelUrl.Visible = false; }));
			LabelCorrectAlbum.Invoke(new MethodInvoker(delegate { LabelCorrectAlbum.Visible = false; }));
			LabelCorrectArtist.Invoke(new MethodInvoker(delegate { LabelCorrectArtist.Visible = false; }));
			LabelCorrectTitle.Invoke(new MethodInvoker(delegate { LabelCorrectTitle.Visible = false; }));
			TextBoxCorrectAlbum.Invoke(new MethodInvoker(delegate { TextBoxCorrectAlbum.Visible = false; }));
			TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate { TextBoxCorrectArtist.Visible = false; }));
			TextBoxCorrectTitle.Invoke(new MethodInvoker(delegate { TextBoxCorrectTitle.Visible = false; }));
			ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Visible = false; }));
			ButtonSkipLyrics.Invoke(new MethodInvoker(delegate { ButtonSkipLyrics.Visible = false; }));
			ButtonSkipYear.Invoke(new MethodInvoker(delegate { ButtonSkipYear.Visible = false; }));
			TextBoxThreadsStatus.Invoke(new MethodInvoker(delegate
			{
				TextBoxThreadsStatus.Select(
					TextBoxThreadsStatus.GetFirstCharIndexFromLine(_numberOfFilesDonePerThread.Count),
					TextBoxThreadsStatus.Lines[_numberOfFilesDonePerThread.Count].Length);
				TextBoxThreadsStatus.SelectedText =
					$"All Files: {_numberOfFilesDone}/{_totalNumberOfFiles} Files Processed. All Done!";
			}));
		}

		private void ButtonTryAgain_Click(object sender, EventArgs e)
		{
			switch (_typeOfException)
			{
				case SongFileProgress.GettingYearException:
					if (_errorSong.IsSingle)
					{
						_errorSong.Title = TextBoxCorrectTitle.Text;
						_errorSong.AlbumArtist = TextBoxCorrectArtist.Text;
					}
					else
					{
						_errorSong.Album = TextBoxCorrectAlbum.Text;
						_errorSong.AlbumArtist = TextBoxCorrectArtist.Text;
					}

					break;
				case SongFileProgress.GettingLyricsException:
					_errorSong.Title = TextBoxCorrectTitle.Text;
					_errorSong.AlbumArtist = TextBoxCorrectArtist.Text;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			BusinessFacade.Instance.TrySongAgain(_threadIdWithError, _errorSong);
			DeactivateCorrectionControls();
		}

		private void ButtonSkipYear_Click(object sender, EventArgs e)
		{
			BusinessFacade.Instance.SkipGettingSongYear(_threadIdWithError, _errorSong);
			DeactivateCorrectionControls();
		}

		private void ButtonSkipLyrics_Click(object sender, EventArgs e)
		{
			BusinessFacade.Instance.SkipGettingSongLyrics(_threadIdWithError, _errorSong);
			DeactivateCorrectionControls();
		}

		private void CheckBoxScrollToEnd_CheckedChanged(object sender, EventArgs e)
		{
			CheckBoxScrollToEnd.ForeColor = CheckBoxScrollToEnd.Checked ? Color.Green : Color.Maroon;
		}

		private void ChangeColorOfLastUsedLineByThread(SongFileProgressEventArgs eventArgs)
		{
			var line = _lastUsedLineByThread[eventArgs.ThreadId];
			var color = eventArgs.Progress switch
			{
				SongFileProgress.GettingLyrics => Color.DarkGreen,
				SongFileProgress.AddingToService => Color.Aquamarine,
				SongFileProgress.FileDone => Color.LimeGreen,
				_ => throw new ArgumentOutOfRangeException(nameof(eventArgs.Progress), eventArgs.Progress, null)
			};

			SyncRichTextBoxArtist.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxArtist.Select(SyncRichTextBoxArtist.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxArtist.Lines[line].Length);
				SyncRichTextBoxArtist.SelectionColor = color;
			}));
			SyncRichTextBoxAlbum.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxAlbum.Select(SyncRichTextBoxAlbum.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxAlbum.Lines[line].Length);
				SyncRichTextBoxAlbum.SelectionColor = color;
			}));
			SyncRichTextBoxTitle.Invoke(new MethodInvoker(delegate
			{
				SyncRichTextBoxTitle.Select(SyncRichTextBoxTitle.GetFirstCharIndexFromLine(line),
					SyncRichTextBoxTitle.Lines[line].Length);
				SyncRichTextBoxTitle.SelectionColor = color;
			}));
		}

		private void SetupThreadsStatus(int numberOfThreads, IEnumerable<int> numberOfFilesPerThreadEnumerable)
		{
			_numberOfFilesDone = 0;
			var numberOfFilesPerThread = numberOfFilesPerThreadEnumerable.ToList();
			_totalNumberOfFiles = numberOfFilesPerThread.Sum();
			for (var index = 0; index < numberOfThreads; index++)
			{
				_numberOfFilesDonePerThread.Add(index, 0);
				_numberOfTotalFilesPerThread.Add(index, numberOfFilesPerThread[index]);
			}

			TextBoxThreadsStatus.Invoke(
				new MethodInvoker(delegate
				{
					for (var index = 0; index < numberOfThreads; index++)
					{
						TextBoxThreadsStatus.AppendText(
							$"Thread {index + 1}: {_numberOfFilesDonePerThread[index]}/{_numberOfTotalFilesPerThread[index]} Files Processed{Environment.NewLine}");
					}

					TextBoxThreadsStatus.AppendText(
						$"All Files: {_numberOfFilesDone}/{_totalNumberOfFiles} Files Processed");
				}));
		}
	}
}