using Business.DTOs;

namespace Business.MusicServices
{
	public interface IMusicService
	{
		void AddSong(SongFileDTO song);
		void DeleteSong(SongFileDTO song);
		int GetPlayCountOfSong(SongFileDTO song);
		void OpenService();
	}
}