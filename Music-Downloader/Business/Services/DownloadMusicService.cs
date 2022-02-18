using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.Enums;
using DB;
using DB.Entities;
using DB.Repositories;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace Business.Services
{
	public class DownloadMusicService
	{
		internal event EventHandler<NewFileEventArgs> NotifyNewDownloadedMusicFile;

		internal event EventHandler<FileMovedArgs> NotifyMusicFileMoved;

		public static DownloadMusicService Instance { get; } = new();
		private readonly string _deemixDirectory, _deemixFilename;
		private readonly string _musicFromDirectory;
		public ISet<string> FilesToMove { get; private set; }
		public ISet<string> DeletedFiles { get; private set; }

		public object FilesToMoveLock = new();
		private Timer _timer;

		private DownloadMusicService()
		{
			_deemixDirectory = @"C:\Users\ruben\Documents\deemix-gui";
			_deemixFilename = "deemix-gui.exe";
			_musicFromDirectory = DirectoriesService.Instance.MusicFromDirectory;
		}

		internal void GetDownloadedMusicFiles()
		{
			FilesToMove = new HashSet<string>();
			DeletedFiles = new HashSet<string>();
			_timer = new Timer();
			_timer.Elapsed += CheckForNewMusicFiles;
			_timer.Interval = 150;
			_timer.Start();
		}


		private void CheckForNewMusicFiles(object source, ElapsedEventArgs e)
		{
			var files = Directory.GetFiles(_musicFromDirectory, "*.mp3",
				SearchOption.TopDirectoryOnly).Distinct();
			lock (FilesToMoveLock)
			{
				foreach (var filePath in files.Where(filePath =>
					!FilesToMove.Contains(Path.GetFileName(filePath)) &&
					!DeletedFiles.Contains(Path.GetFileName(filePath))))
				{
					var fileName = Path.GetFileName(filePath);
					fileName = UnCensorFilename(fileName);
					FilesToMove.Add(fileName);
					NotifyNewDownloadedMusicFile?.Invoke(this,
						new NewFileEventArgs {Filename = fileName});
				}
			}
		}

		internal static string UnCensorFilename(string fileName)
		{
			return fileName.Replace("f_ck", "fuck").Replace("f___", "fuck").Replace("f__k", "fuck")
				.Replace("sh_t", "shit")
				.Replace("s__t", "shit").Replace("sh__", "shit").Replace("ni__as", "niggas").Replace(
					"F_ck", "Fuck").Replace("F__k", "Fuck").Replace("F___", "Fuck").Replace("Sh_t", "Shit")
				.Replace("S__t", "Shit").Replace("Sh__", "Shit").Replace("Ni__as", "Niggas");
		}

		private static bool IsDeemixRunning()
		{
			return Process.GetProcessesByName("deemix-gui").Length != 0;
		}

		internal async Task StartDeemix()
		{
			await Task.Run(() =>
			{
				if (IsDeemixRunning()) return;
				var deemix = new Process {StartInfo = {FileName = Path.Combine(_deemixDirectory, _deemixFilename)}};
				deemix.Start();
			});
		}

		internal void MoveFiles()
		{
			_timer.Stop();
			var musicToDirectory = DirectoriesService.Instance.MusicToDirectory;
			if (!Directory.Exists(musicToDirectory))
			{
				Directory.CreateDirectory(musicToDirectory);
			}

			foreach (var originFilename in FilesToMove)
			{
				var originFilePath = Path.Combine(_musicFromDirectory, originFilename);
                var fileNameWithRemovedWords = SongFileDTO.RemoveWordsInParenthesisFromWord(new List<string>() { "Remaster", "Anniversary", "Expanded", "Digital Master" }, originFilename);
                var destinationFilePath = Path.Combine(musicToDirectory, fileNameWithRemovedWords);
				if (!File.Exists(originFilePath))
				{
					DeletedFiles.Add(originFilename);
					continue;
				}

				if (File.Exists(destinationFilePath))
				{
					var newSong = SongFileDTO.GetSongFileDTOFromFilePath(originFilePath);
					var oldSong = SongFileDTO.GetSongFileDTOFromFilePath(destinationFilePath);
                    newSong.Filename = fileNameWithRemovedWords;
					if (oldSong.AlbumArtist == newSong.AlbumArtist && oldSong.Album != newSong.Album)
					{
						if (oldSong.IsSingle)
                        {
							MoveFile(originFilePath, destinationFilePath, FileMovedCondition.ReplacedSingle, newSong);
						}
						else
						{
							newSong.RenameSongFile(RenameFileOptions.AddAlbum);
							destinationFilePath = Path.Combine(musicToDirectory, newSong.Filename);
							MoveFile(originFilePath, destinationFilePath, FileMovedCondition.HadToBeRenamed, newSong);
						}
					}
					else if (oldSong.AlbumArtist == newSong.AlbumArtist && oldSong.Album == newSong.Album)
					{
						MoveFile(originFilePath, destinationFilePath,
							oldSong.IsSingle ? FileMovedCondition.ReplacedSingle : FileMovedCondition.AlreadyExists,
							newSong);
					}
					else
					{
						newSong.RenameSongFile(RenameFileOptions.AddArtist);
						destinationFilePath = Path.Combine(musicToDirectory, newSong.Filename);
						MoveFile(originFilePath, destinationFilePath, FileMovedCondition.HadToBeRenamed, newSong);
					}
				}
				else
				{
					MoveFile(originFilePath, destinationFilePath, FileMovedCondition.NoProblem,
						SongFileDTO.GetSongFileDTOFromFilePath(originFilePath));
				}
			}

			RecycleDeletedFiles();
		}

		private void RecycleDeletedFiles()
		{
			var musicFromDirectory = DirectoriesService.Instance.MusicFromDirectory;
			foreach (var deletedFile in DeletedFiles)
			{
				FileSystem.DeleteFile(Path.Combine(musicFromDirectory, deletedFile), UIOption.OnlyErrorDialogs,
					RecycleOption.SendToRecycleBin);
			}
		}

		private void MoveFile(string originFilePath, string destinationFilePath, FileMovedCondition condition,
			SongFileDTO song)
		{
			if (condition != FileMovedCondition.AlreadyExists)
			{
				if (condition == FileMovedCondition.ReplacedSingle || condition == FileMovedCondition.HadToBeRenamed && File.Exists(destinationFilePath))
				{
					BusinessFacade.Instance.MusicService.DeleteSong(
						SongFileDTO.GetSongFileDTOFromFilePath(destinationFilePath));
					if (condition == FileMovedCondition.ReplacedSingle)
					    SongService.Instance.RemoveSingle(song);
					FileSystem.DeleteFile(destinationFilePath, UIOption.OnlyErrorDialogs,
						RecycleOption.SendToRecycleBin);
				}

                File.Move(originFilePath,
                    destinationFilePath);
			}
			else
			{
				DeletedFiles.Add(Path.GetFileName(originFilePath));
			}

			GetLyricsAndYearService.Instance.SongsToGetDetails.Add(song);
			NotifyMusicFileMoved?.Invoke(this,
				new FileMovedArgs() {Filename = Path.GetFileName(destinationFilePath), Condition = condition});
		}

		public void KillDeemix()
		{
			try
			{
				foreach (var process in Process.GetProcesses())
				{
					Debug.WriteLine(process.ProcessName);
				}

				foreach (var process in Process.GetProcessesByName("deemix-gui"))
				{
					process.Kill();
				}
			}
			catch (IndexOutOfRangeException)
			{
			}
		}
	}
}