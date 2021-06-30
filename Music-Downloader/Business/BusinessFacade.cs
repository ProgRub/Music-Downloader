using System;
using System.Diagnostics;
using System.IO;
using Business.CustomEventArgs;
using Business.Services;

namespace Business
{
    public class BusinessFacade
    {
        private BusinessFacade()
        {
        }

        public event EventHandler<NewFileEventArgs> NotifyNewDownloadedMusicFile;
        public event EventHandler<FileMovedArgs> NotifyMusicFileMoved;
        public static BusinessFacade Instance { get; } = new();

        public void GetDownloadedMusicFiles()
        {
            DownloadMusicService.Instance.NotifyNewDownloadedMusicFile += (sender, args) =>NotifyNewDownloadedMusicFile?.Invoke(sender, args);
            DownloadMusicService.Instance.GetDownloadedMusicFiles();
        }

        public void StartDeemix(){}// => DownloadMusicService.Instance.StartDeemix();

        internal void StopTimer() => DownloadMusicService.Instance.StopTimer();
        public void MoveFiles()
        {
            DownloadMusicService.Instance.NotifyMusicFileMoved += (sender, args) => NotifyMusicFileMoved?.Invoke(sender, args);
            DownloadMusicService.Instance.MoveFiles();
        } 
    }
}