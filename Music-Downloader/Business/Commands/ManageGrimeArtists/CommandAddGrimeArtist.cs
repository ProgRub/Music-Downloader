using Business.Services;

namespace Business.Commands.ManageGrimeArtists
{
	public class CommandAddGrimeArtist:ICommand
	{
		private string _artistName;

		public CommandAddGrimeArtist(string artistName)
		{
			_artistName = artistName;
		}
		public void Execute() => GrimeArtistService.Instance.AddGrimeArtist(_artistName,false);

		public void Undo() => GrimeArtistService.Instance.RemoveGrimeArtist(_artistName);

		public void Redo() => Execute();
	}
}