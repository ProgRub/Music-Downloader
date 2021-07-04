using System;
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

		private IDictionary<int, int> _numberOfFilesDonePerThread =
			new Dictionary<int, int>();

		private IDictionary<int, int> _numberOfTotalFilesPerThread =
			new Dictionary<int, int>();

		private IDictionary<int, int> _lastUsedLineByThread = new Dictionary<int, int>();
		private Stopwatch _timeElapsed;
		private Timer _clock;
		private SongFileDTO _errorSong;
		private SongFileProgress _typeOfException;
		private int _threadIdWithError;

		public object Mutex { get; set; } = new();

		public GetYearAndLyricsScreen()
		{
			InitializeComponent();
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
					lock (Mutex)
					{
						UIChanges(args);
					}
				};

			BusinessFacade.Instance.NotifyInitialThreadsConfiguration += (_, args) =>
				SetupThreadsStatus(args.NumberOfThreads, args.NumberOfFilesPerThread);
			MaximizeWindow();
			SetFormAcceptButton(ButtonTryAgain);
			BusinessFacade.Instance.OpenService();
			Task.Delay(250).ContinueWith(_ => BusinessFacade.Instance.StartGettingYearAndLyrics());
		}

		private void Clock_Tick(object sender, EventArgs e)
		{
			var elapsedTime = _timeElapsed.Elapsed;
			LabelTimeElapsed.Text =
				$"Time Elapsed: {elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
		}

		private void UIChanges(SongFileProgressEventArgs eventArgs)
		{
			int line;
			switch (eventArgs.Progress)
			{
				case SongFileProgress.GettingYear:
					line = _lastWrittenLineIndex;
					_lastUsedLineByThread[eventArgs.ThreadId] = _lastWrittenLineIndex++;
					RichTextBoxArtist.Invoke(new MethodInvoker(delegate
					{
						RichTextBoxArtist.AppendText((line > 0 ? Environment.NewLine : "") +
						                             eventArgs.Song.AlbumArtist);
						RichTextBoxArtist.ScrollToCaret();
					}));
					RichTextBoxAlbum.Invoke(new MethodInvoker(delegate
					{
						RichTextBoxAlbum.AppendText((line > 0 ? Environment.NewLine : "") + eventArgs.Song.Album);
						RichTextBoxAlbum.ScrollToCaret();
					}));
					RichTextBoxTitle.Invoke(new MethodInvoker(delegate
					{
						RichTextBoxTitle.AppendText((line > 0 ? Environment.NewLine : "") + eventArgs.Song.Title);
						RichTextBoxTitle.ScrollToCaret();
					}));
					break;
				case SongFileProgress.GettingYearException:
					SystemSounds.Exclamation.Play();
					LabelUrl.Invoke(new MethodInvoker(delegate { LabelUrl.Text = eventArgs.Url; }));
					ActivateCorrectionControls(eventArgs);
					_threadIdWithError = eventArgs.ThreadId;
					break;
				case SongFileProgress.GettingLyrics:
					ChangeColorOfLastUsedLineByThread(eventArgs);
					_numberOfFilesDone++;
					_numberOfFilesDonePerThread[eventArgs.ThreadId]++;
					TextBoxThreadsStatus.Invoke(
						new MethodInvoker(delegate
						{
							TextBoxThreadsStatus.Select(
								TextBoxThreadsStatus.GetFirstCharIndexFromLine(eventArgs.ThreadId),
								TextBoxThreadsStatus.Lines[eventArgs.ThreadId].Length);
							TextBoxThreadsStatus.SelectedText =
								$"Thread {eventArgs.ThreadId + 1}: {_numberOfFilesDonePerThread[eventArgs.ThreadId]}/{_numberOfTotalFilesPerThread[eventArgs.ThreadId]} Files Processed";
							TextBoxThreadsStatus.Select(
								TextBoxThreadsStatus.GetFirstCharIndexFromLine(_lastUsedLineByThread.Count),
								TextBoxThreadsStatus.Lines[_lastUsedLineByThread.Count].Length);
							TextBoxThreadsStatus.SelectedText =
								$"All Files: {_numberOfFilesDone}/{_totalNumberOfFiles} Files Processed";
						}));
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
						}));
						TextBoxCorrectTitle.Invoke(
							new MethodInvoker(delegate
							{
								TextBoxCorrectTitle.Enabled = true;
								TextBoxCorrectTitle.Text = _errorSong.Title;
							}));
						ButtonTryAgain.Invoke(new MethodInvoker(delegate { ButtonTryAgain.Enabled = true; }));
						ButtonSkipLyrics.Invoke(new MethodInvoker(delegate { ButtonSkipLyrics.Enabled = true; }));
						ButtonSkipYear.Invoke(new MethodInvoker(delegate { ButtonSkipYear.Enabled = true; }));
					}
					else
					{
						TextBoxCorrectAlbum.Invoke(
							new MethodInvoker(delegate
							{
								TextBoxCorrectAlbum.Enabled = true;
								TextBoxCorrectAlbum.Text = _errorSong.Album;
							}));
						TextBoxCorrectArtist.Invoke(new MethodInvoker(delegate
						{
							TextBoxCorrectArtist.Enabled = true;
							TextBoxCorrectArtist.Text = _errorSong.AlbumArtist;
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

		private void ChangeColorOfLastUsedLineByThread(SongFileProgressEventArgs eventArgs)
		{
			var line = _lastUsedLineByThread[eventArgs.ThreadId];
			Color color = eventArgs.Progress switch
			{
				SongFileProgress.GettingLyrics => Color.DarkGreen,
				SongFileProgress.AddingToService => Color.Aquamarine,
				SongFileProgress.FileDone => Color.LimeGreen,
				_ => throw new ArgumentOutOfRangeException(nameof(eventArgs.Progress), eventArgs.Progress, null)
			};

			RichTextBoxArtist.Invoke(new MethodInvoker(delegate
			{
				RichTextBoxArtist.Select(RichTextBoxArtist.GetFirstCharIndexFromLine(line),
					RichTextBoxArtist.Lines[line].Length);
				RichTextBoxArtist.SelectionColor = color;
			}));
			RichTextBoxAlbum.Invoke(new MethodInvoker(delegate
			{
				RichTextBoxAlbum.Select(RichTextBoxAlbum.GetFirstCharIndexFromLine(line),
					RichTextBoxAlbum.Lines[line].Length);
				RichTextBoxAlbum.SelectionColor = color;
			}));
			RichTextBoxTitle.Invoke(new MethodInvoker(delegate
			{
				RichTextBoxTitle.Select(RichTextBoxTitle.GetFirstCharIndexFromLine(line),
					RichTextBoxTitle.Lines[line].Length);
				RichTextBoxTitle.SelectionColor = color;
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