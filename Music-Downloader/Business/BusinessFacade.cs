using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.Enums;
using Business.Services;
using Business.Services.MusicServices;
using Business.SongDetailsScrapers;
using DB.Entities;

namespace Business
{
	public class BusinessFacade
	{
		public event EventHandler<NewFileEventArgs> NotifyNewDownloadedMusicFile;
		public event EventHandler<FileMovedArgs> NotifyMusicFileMoved;
		public event EventHandler<SongFileProgressEventArgs> NotifySongFileProgress;
		public event EventHandler<ThreadsConfigurationEventArgs> NotifyInitialThreadsConfiguration;
		private IMusicService _musicService;
		public static BusinessFacade Instance { get; } = new();

		private BusinessFacade()
		{
			SetMusicService("iTunes");
			DownloadMusicService.Instance.NotifyNewDownloadedMusicFile +=
				(sender, args) => NotifyNewDownloadedMusicFile?.Invoke(sender, args);
			DownloadMusicService.Instance.NotifyMusicFileMoved +=
				(sender, args) => NotifyMusicFileMoved?.Invoke(sender, args);
			GetLyricsAndYearService.Instance.NotifySongFileProgress +=
				(sender, args) => NotifySongFileProgress?.Invoke(sender, args);
			GetLyricsAndYearService.Instance.NotifyInitialThreadsConfiguration +=
				(sender, args) => NotifyInitialThreadsConfiguration?.Invoke(sender, args);
		}

		public void GetDownloadedMusicFiles() => DownloadMusicService.Instance.GetDownloadedMusicFiles();
		
		public async Task StartDeemix() => await DownloadMusicService.Instance.StartDeemix();

		public void MoveFiles() => DownloadMusicService.Instance.MoveFiles();

		public async Task KillDeemix()
		{
			await Task.Run(() =>
			{
				try
				{
					Process.GetProcessesByName("python")[0].Kill();
				}
				catch (IndexOutOfRangeException)
				{
				}
			});
		}

		public void StartGettingYearAndLyrics()
		{
			GetLyricsAndYearService.Instance.StartThreads();
		}

		public void SetMusicService(string type)
		{
			_musicService = type switch
			{
				"iTunes" => iTunesService.Instance,
				_ => _musicService
			};
		}

		public void OpenService() => _musicService.OpenService();
		public void AddSongToService(SongFileDTO song) => _musicService.AddSong(song);

		public void TrySongAgain(int threadId, SongFileDTO correctedSong)
		{
			SongDetailsTemplateMethod.DetailsGetters.First(e => e.ThreadId == threadId).CurrentSong = correctedSong;
			SongDetailsTemplateMethod.SemaphoreErrorHandled.Release();
		}

		public void SkipGettingSongYear(int threadId, SongFileDTO errorSong)
		{
			SongDetailsTemplateMethod.DetailsGetters.First(e => e.ThreadId == threadId).SkipYear = true;
			SongDetailsTemplateMethod.SemaphoreErrorHandled.Release();
		}

		public void SkipGettingSongLyrics(int threadId, SongFileDTO errorSong)
		{
			SongDetailsTemplateMethod.DetailsGetters.First(e => e.ThreadId == threadId).SkipLyrics = true;
			SongDetailsTemplateMethod.SemaphoreErrorHandled.Release();
		}

		public void SaveExceptions() => ExceptionsService.Instance.SaveChanges();

		public string GetMusicFromDirectory() => DirectoriesService.Instance.MusicFromDirectory;

		public string GetMusicToDirectory() => DirectoriesService.Instance.MusicToDirectory;

		public void SetMusicFromDirectory(string directory) =>
			DirectoriesService.Instance.MusicFromDirectory = directory;

		public void SetMusicToDirectory(string directory) =>
			DirectoriesService.Instance.MusicToDirectory = directory;

		public void LoadDatabase() => ExceptionsService.Instance.GetAllSkipLyricsExceptions();

		public void SaveDirectories() => DirectoriesService.Instance.SaveDirectories();

		public IEnumerable<ExceptionDTO> GetAllExceptions() => ExceptionsService.Instance.GetAllExceptions()
			.Select(ExceptionDTO.ConvertYearLyricsChangeDetailsExceptionToDto);
	}
}