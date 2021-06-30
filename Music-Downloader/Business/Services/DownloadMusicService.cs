using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using Business.CustomEventArgs;
using Business.DTOs;
using DB;
using DB.Repositories;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace Business.Services
{
    public class DownloadMusicService
    {
        public event EventHandler<NewFileEventArgs> NotifyNewDownloadedMusicFile;

        public event EventHandler<FileMovedArgs> NotifyMusicFileMoved;

        private DownloadMusicService()
        {
            _deemixDirectory = Path.GetFullPath(Directory.GetCurrentDirectory().Contains("GitHub")
                ? Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\..\..\"),
                    "deemix-pyweb-main")
                : Path.Combine(Directory.GetCurrentDirectory(), "deemix-pyweb-main"));
            _deemixFilename = "deemix-pyweb.py";
            _musicFromDirectory = DirectoriesService.Instance.MusicFromDirectory;
        }

        public static DownloadMusicService Instance { get; } = new();
        private readonly string _deemixDirectory, _deemixFilename;
        private readonly string _musicFromDirectory;
        public ISet<string> FilesToMove { get; } = new HashSet<string>();
        public ISet<string> DeletedFiles { get; } = new HashSet<string>();

        public object FilesToMoveLock = new();
        private Timer _timer;

        internal void GetDownloadedMusicFiles()
        {
            _timer = new Timer();
            _timer.Elapsed += CheckForNewMusicFiles;
            _timer.Interval = 150;
            _timer.Start();
        }

        internal void StopTimer() => _timer.Stop();

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
                    FilesToMove.Add(Path.GetFileName(filePath));
                    NotifyNewDownloadedMusicFile?.Invoke(this,
                        new NewFileEventArgs {Filename = Path.GetFileName(filePath)});
                }
            }
        }

        private string GetMostRecentPythonExecutable()
        {
            return Path.Combine(
                Directory.EnumerateDirectories("C:\\").Where(e => e.Contains("Python")).OrderByDescending(e => e)
                    .First(), "python.exe");
        }

        private bool IsDeemixRunning()
        {
            return Process.GetProcessesByName("python").Length != 0;
        }

        internal void StartDeemix()
        {
            if (IsDeemixRunning()) return;
            var deemix = new Process
            {
                StartInfo = new ProcessStartInfo(GetMostRecentPythonExecutable(),
                    Path.Combine(_deemixDirectory, _deemixFilename))
                {
                    RedirectStandardOutput = true, UseShellExecute = false
                }
            };
            deemix.Start();
        }

        internal void MoveFiles()
        {
            var musicToDirectory = DirectoriesService.Instance.MusicToDirectory;
            if (!Directory.Exists(musicToDirectory))
            {
                Directory.CreateDirectory(musicToDirectory);
            }

            foreach (var originFilename in FilesToMove)
            {
                var originFilePath = Path.Combine(_musicFromDirectory, originFilename);
                var destinationFilePath = Path.Combine(musicToDirectory, originFilename);
                if (!File.Exists(originFilePath))
                {
                    DeletedFiles.Add(originFilename);
                    continue;
                }

                if (File.Exists(destinationFilePath))
                {
                    var newSong = SongFileDTO.GetSongFileDTOFromFilePath(originFilePath);
                    var oldSong = SongFileDTO.GetSongFileDTOFromFilePath(destinationFilePath);
                    if (oldSong.AlbumArtist == newSong.AlbumArtist && oldSong.Album != newSong.Album)
                    {
                        if (oldSong.IsSingle)
                        {
                            MoveFile(originFilePath, destinationFilePath, FileMovedCondition.ReplacedSingle);
                        }
                        else
                        {
                            newSong.RenameSongFile(RenameFileOptions.AddAlbum);
                            destinationFilePath = Path.Combine(musicToDirectory, newSong.Filename);
                            MoveFile(originFilePath, destinationFilePath, FileMovedCondition.HadToBeRenamed);
                        }
                    }
                    else if (oldSong.AlbumArtist == newSong.AlbumArtist && oldSong.Album == newSong.Album)
                    {
                        MoveFile(originFilePath, destinationFilePath, FileMovedCondition.AlreadyExists);
                    }
                    else
                    {
                        newSong.RenameSongFile(RenameFileOptions.AddArtist);
                        destinationFilePath = Path.Combine(musicToDirectory, newSong.Filename);
                        MoveFile(originFilePath, destinationFilePath, FileMovedCondition.HadToBeRenamed);
                    }
                }
                else
                {
                    MoveFile(originFilePath, destinationFilePath, FileMovedCondition.NoProblem);
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

        private void MoveFile(string originFilePath, string destinationFilePath, FileMovedCondition condition)
        {
            if (condition != FileMovedCondition.AlreadyExists)
            {
                File.Move(originFilePath,
                    destinationFilePath);
            }

            NotifyMusicFileMoved?.Invoke(this,
                new FileMovedArgs() {Filename = Path.GetFileName(destinationFilePath), Condition = condition});
        }
    }
}