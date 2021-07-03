using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Business.CustomEventArgs;
using Business.DTOs;
using Business.SongDetailsScrapers;
using DB.Entities;

namespace Business.Services
{
	public class GetLyricsAndYearService
	{
		private static int NumberOfThreads = (int) Math.Pow(2, (int) Math.Sqrt(Environment.ProcessorCount));
		internal event EventHandler<SongFileProgressEventArgs> NotifySongFileProgress;
		internal event EventHandler<ThreadsConfigurationEventArgs> NotifyInitialThreadsConfiguration;
		

		private GetLyricsAndYearService()
		{
		}

		public static GetLyricsAndYearService Instance { get; } = new();

		public ISet<SongFileDTO> SongsToGetDetails { get; } = new HashSet<SongFileDTO>();


		public void StartThreads()
		{
			var totalNumberOfSongs = SongsToGetDetails.Count;
			NumberOfThreads = Math.Min(totalNumberOfSongs, NumberOfThreads);
			var rest = totalNumberOfSongs % NumberOfThreads;
			var result = totalNumberOfSongs / (double) NumberOfThreads;
			var filesPerThreadList = new List<int>();

			for (var i = 0; i < NumberOfThreads; i++)
			{
				if (rest-- > 0)
					filesPerThreadList.Add((int) Math.Ceiling(result));
				else
					filesPerThreadList.Add((int) Math.Floor(result));
			}

			NotifyInitialThreadsConfiguration?.Invoke(this,
				new ThreadsConfigurationEventArgs
					{NumberOfThreads = NumberOfThreads, NumberOfFilesPerThread = filesPerThreadList});

			var previousFiles = 0;
			for (var index = 0; index < NumberOfThreads; index++)
			{
				var aux = new Thread(ThreadFunction)
				{
					IsBackground = true
				};
				if (index != 0)
				{
					previousFiles += filesPerThreadList[index - 1];
				}

				aux.Start(new object[2]
					{index, SongsToGetDetails.Skip(previousFiles).Take(filesPerThreadList[index]).ToHashSet()});
			}

			//this.FinishedAllFiles();
			//var saveExceptions = new Thread(this.Window.LAFContainer.SaveExceptions);
			//var saveMFs = new Thread(this.Window.LAFContainer.SaveMusicFiles);
			//saveExceptions.Start();
			//saveMFs.Start();
		}

		internal void ThreadFunction(object parameters)
		{
			var argArray = (Array) parameters;
			var geniusDetailsScraper =
				new GeniusDetailsScraper((HashSet<SongFileDTO>) argArray.GetValue(1), (int) argArray.GetValue(0));
			geniusDetailsScraper.NotifySongFileProgress +=
				(sender, args) => NotifySongFileProgress?.Invoke(sender, args);
			geniusDetailsScraper.GetYearAndLyricsOfSongs();
		}
	}
}