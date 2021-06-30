using System.Diagnostics;
using System.IO;
using System.Linq;
using Business.Services;

namespace Business.Commands.DownloadMusic
{
    public class CommandRenameFile : ICommand
    {
        private readonly string _oldFilePath, _newFilePath;

        public CommandRenameFile(string oldFilename, string newFilename)
        {
            _oldFilePath = Path.Combine(DirectoriesService.Instance.MusicFromDirectory, oldFilename);
            _newFilePath = Path.Combine(DirectoriesService.Instance.MusicFromDirectory, newFilename);
        }

        public void Execute()
        {
            File.Move(_oldFilePath, _newFilePath);
            lock (DownloadMusicService.Instance.FilesToMoveLock)
            {
                DownloadMusicService.Instance.FilesToMove.Remove(Path.GetFileName(_oldFilePath));
                DownloadMusicService.Instance.FilesToMove.Add(Path.GetFileName(_newFilePath));
            }
        }

        public void Undo()
        {
            File.Move(_newFilePath, _oldFilePath);
            lock (DownloadMusicService.Instance.FilesToMoveLock)
            {
                DownloadMusicService.Instance.FilesToMove.Remove(Path.GetFileName(_newFilePath));
                DownloadMusicService.Instance.FilesToMove.Add(Path.GetFileName(_oldFilePath));
            }
        }

        public void Redo()
        {
            Execute();
        }
    }
}