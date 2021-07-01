﻿using System.IO;
using DB;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
    public class DirectoriesService
    {
        private IDirectoriesRepository _directoriesRepository;
        private DirectoriesService(IDirectoriesRepository directoriesRepository)
        {
            _directoriesRepository = directoriesRepository;
            var allDirectories = _directoriesRepository.GetById(1);
            MusicFromDirectory = allDirectories.MusicFrom;
            MusicToDirectory = allDirectories.MusicTo;
            UniFromDirectory = allDirectories.UniFrom;
            UniToBaseDirectory = allDirectories.UniToBaseDirectory;
        }
        internal string MusicFromDirectory { get; set; }
        internal string MusicToDirectory { get; set; }
        internal string UniFromDirectory { get; set; }
        internal string UniToBaseDirectory { get; set; }
        public static DirectoriesService Instance { get; } = new(new DirectoriesRepository(Database.GetContext()));
    }
}