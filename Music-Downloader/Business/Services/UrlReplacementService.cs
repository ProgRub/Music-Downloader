using System.Collections.Generic;
using System.Linq;
using DB;
using DB.Entities;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	internal class UrlReplacementService
	{
		private readonly IUrlReplacementRepository _urlReplacementRepository;

		private ICollection<string> _deletedUrlReplacementKeys =
			new List<string>();

		private UrlReplacementService()
		{
			_urlReplacementRepository = new UrlReplacementRepository(Database.GetContext());
		}

		internal static UrlReplacementService Instance { get; } = new();

		internal IDictionary<string, string> GetAllUrlReplacements()
		{
			return _urlReplacementRepository.GetAll().ToDictionary(urlReplacement => urlReplacement.StringToReplace,
				urlReplacement => urlReplacement.StringReplacement);
		}

		internal void RemoveUrlReplacement(string urlReplacementKey)
		{
			_deletedUrlReplacementKeys.Add(urlReplacementKey);
		}

		internal void AddUrlReplacement(string urlReplacementKey)
		{
			_deletedUrlReplacementKeys.Remove(urlReplacementKey);
		}

		internal void AddUrlReplacement(string toReplace, string replacement)
		{
			_urlReplacementRepository.Add(new UrlReplacement
				{StringToReplace = toReplace, StringReplacement = replacement});
		}

		internal UrlReplacement GetUrlReplacementByToReplace(string toReplace) =>
			_urlReplacementRepository.Find(e => e.StringToReplace == toReplace).First();

		internal void SaveChanges()
		{
			foreach (var deletedUrlReplacementKey in _deletedUrlReplacementKeys)
			{
				_urlReplacementRepository.Remove(_urlReplacementRepository
					.Find(e => e.StringToReplace == deletedUrlReplacementKey).First());
			}

			_urlReplacementRepository.SaveChanges();
		}
	}
}