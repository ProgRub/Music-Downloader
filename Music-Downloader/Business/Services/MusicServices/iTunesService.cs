using System.IO;
using Business.DTOs;
using iTunesLib;

namespace Business.Services.MusicServices
{
    public class iTunesService : IMusicService
    {
        private iTunesService()
        {
        }

        private iTunesApp _iTunes;
        private IITLibraryPlaylist _iTunesLibrary;

        public static IMusicService Instance { get; } = new iTunesService();

        public void AddSong(SongFileDTO song)
        {
            if (_iTunes == null)
            {
                OpenService();
            }

            _iTunesLibrary.AddFile(Path.Combine(DirectoriesService.Instance.MusicToDirectory, song.Filename));
        }

        public void DeleteSong(SongFileDTO song)
        {
	        throw new System.NotImplementedException();
        }

        public int GetPlayCountOfSong(SongFileDTO song)
        {
	        throw new System.NotImplementedException();
        }

        public void OpenService()
        {
            _iTunes = new iTunesApp();
            _iTunesLibrary = _iTunes.LibraryPlaylist;
        }
    }
}