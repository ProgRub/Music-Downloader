using Business.Enums;
using DB.Entities;

namespace Business.DTOs
{
	public class ExceptionDTO
	{
		public int Id { get; init; }
		public string OriginalArtist { get; set; }
		public string OriginalAlbum { get; set; }
		public string OriginalTitle { get; set; }
		public string NewArtist { get; set; }
		public string NewAlbum { get; set; }
		public string NewTitle { get; set; }
		public ExceptionType Type { get; set; }

		internal static ExceptionDTO ConvertYearLyricsChangeDetailsExceptionToDto(
			YearLyricsChangeDetailsException exception)
		{
			return new()
			{
				Id = exception.Id,
				OriginalArtist = exception.OriginalArtist, OriginalAlbum = exception.OriginalAlbum,
				OriginalTitle = exception.OriginalTitle,
				NewArtist = exception.NewArtist, NewAlbum = exception.NewAlbum, NewTitle = exception.NewTitle,
				Type = (ExceptionType) exception.Type
			};
		}
	}
}