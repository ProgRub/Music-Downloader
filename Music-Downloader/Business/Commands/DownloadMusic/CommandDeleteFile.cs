using Business.Services;

namespace Business.Commands.DownloadMusic
{
	public class CommandDeleteFile : ICommand
	{
		private readonly string _filename;

		public CommandDeleteFile(string filename)
		{
			_filename = filename;
		}

		public void Execute()
		{
			DownloadMusicService.Instance.DeletedFiles.Add(_filename);
			DownloadMusicService.Instance.FilesToMove.Remove(_filename);
		}

		public void Undo()
		{
			DownloadMusicService.Instance.FilesToMove.Add(_filename);
			DownloadMusicService.Instance.DeletedFiles.Remove(_filename);
		}

		public void Redo()
		{
			Execute();
		}
	}
}