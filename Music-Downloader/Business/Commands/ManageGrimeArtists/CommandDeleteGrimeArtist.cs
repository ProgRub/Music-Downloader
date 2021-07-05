using Business.Services;

namespace Business.Commands.ManageGrimeArtists
{
	public class CommandDeleteGrimeArtist:ICommand
	{
		private string _artistName;

		public CommandDeleteGrimeArtist(string artistName)
		{
			_artistName = artistName;
		}

		public void Execute() => GrimeArtistService.Instance.RemoveGrimeArtist(_artistName);

		public void Undo() => GrimeArtistService.Instance.AddGrimeArtist(_artistName, true);

		public void Redo() => Execute();
	}
}