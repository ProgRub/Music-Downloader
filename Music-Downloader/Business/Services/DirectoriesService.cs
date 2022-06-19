using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Business.DTOs;
using DB;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class DirectoriesService
	{
		private readonly IDirectoriesRepository _directoriesRepository;

		private DirectoriesService(IDirectoriesRepository directoriesRepository)
		{
			_directoriesRepository = directoriesRepository;
			var allDirectories = _directoriesRepository.GetById(1);
			MusicFromDirectory = allDirectories.MusicFrom;
			MusicToDirectory = allDirectories.MusicTo;
		}

		internal string MusicFromDirectory { get; set; }
		internal string MusicToDirectory { get; set; }
		public static DirectoriesService Instance { get; } = new(new DirectoriesRepository(Database.GetContext()));

		internal ISet<SongFileDTO> GetAllStoredSongs()
		{
			return Directory.GetFiles(MusicToDirectory, "*.mp3",
				SearchOption.TopDirectoryOnly).Select(e =>
				SongFileDTO.GetSongFileDTOFromFilePath(Path.Combine(MusicToDirectory, e))).ToHashSet();
		}

		public void SaveChanges()
		{
			var directories = _directoriesRepository.GetById(1);
			directories.MusicFrom = MusicFromDirectory;
			directories.MusicTo = MusicToDirectory;
			_directoriesRepository.SaveChanges();
		}
	}
}