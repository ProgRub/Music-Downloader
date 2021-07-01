using System.Collections.Generic;
using System.Linq;
using DB;
using DB.Repositories.Implementations;
using DB.Repositories.Interfaces;

namespace Business.Services
{
    public class UrlReplacementService
    {
        private IUrlReplacementRepository _urlReplacementRepository;

        private UrlReplacementService()
        {
            _urlReplacementRepository = new UrlReplacementRepository(Database.GetContext());
        }

        public static UrlReplacementService Instance { get; } = new();

        internal IEnumerable<KeyValuePair<string, string>> GetAllUrlReplacements()
        {
            return _urlReplacementRepository.GetAll().Select(e=>new KeyValuePair<string, string>(e.StringToReplace,e.StringReplacement));
        }
    }
}