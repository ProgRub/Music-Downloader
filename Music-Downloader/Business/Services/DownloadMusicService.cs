using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using Business.CustomEventArgs;
using DB;
using DB.Repositories;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

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
            _timer= new Timer();
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
                foreach (var filePath in files.Where(filename => !FilesToMove.Contains(filename)))
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
                var destinationFilename = originFilename;
                var originFilePath = Path.Combine(_musicFromDirectory, originFilename);
                var destinationFilePath = Path.Combine(musicToDirectory, destinationFilename);
                if (File.Exists(destinationFilePath))
                {

                }
                else
                {
                    File.Move(originFilePath,
                        destinationFilePath);
                }
            }
        }
    }
}