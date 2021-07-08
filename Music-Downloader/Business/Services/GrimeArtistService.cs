using System.Collections.Generic;
using System.Linq;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class GrimeArtistService
	{
		private IGrimeArtistRepository _grimeArtistRepository;

		private readonly ICollection<string> _deletedGrimeArtists=
			new List<string>();
		private GrimeArtistService()
		{
			_grimeArtistRepository = new GrimeArtistRepository(Database.GetContext());
		}
		internal static GrimeArtistService Instance { get; } = new();

		internal void RemoveGrimeArtist(string grimeArtist)
		{
			_deletedGrimeArtists.Add(grimeArtist);
		}

		internal void AddGrimeArtist(string grimeArtist,bool deletedBeforeAdded)
		{
			if(deletedBeforeAdded)
			{
				_deletedGrimeArtists.Remove(grimeArtist);
				return;
			}
			_grimeArtistRepository.Add(new GrimeArtist{ArtistName = grimeArtist});
		}

		internal void SaveChanges()
		{
			foreach (var deletedGrimeArtist in _deletedGrimeArtists)
			{
				_grimeArtistRepository.Remove(_grimeArtistRepository
					.Find(e => e.ArtistName == deletedGrimeArtist).First());
			}

			_grimeArtistRepository.SaveChanges();
			_deletedGrimeArtists.Clear();
		}

		public IEnumerable<string> GetAllGrimeArtists() => _grimeArtistRepository.GetAll().Select(e => e.ArtistName);
	}
}