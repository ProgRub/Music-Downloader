using System.Collections.Generic;
using System.Linq;
using DB;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
	public class UrlReplacementService
	{
		private readonly IUrlReplacementRepository _urlReplacementRepository;

		private UrlReplacementService()
		{
			_urlReplacementRepository = new UrlReplacementRepository(Database.GetContext());
		}

		public static UrlReplacementService Instance { get; } = new();

		internal IDictionary<string,string> GetAllUrlReplacements()
		{
			return _urlReplacementRepository.GetAll().ToDictionary(urlReplacement => urlReplacement.StringToReplace, urlReplacement => urlReplacement.StringReplacement);
		}
	}
}