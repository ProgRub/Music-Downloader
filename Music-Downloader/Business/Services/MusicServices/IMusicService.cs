using Business.DTOs;

namespace Business.MusicServices
{
    public interface IMusicService
    {
        void AddSong(SongFileDTO song);
        void OpenService();
    }
}