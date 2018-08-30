using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    class SearchSitesModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string source { get; set; }
        public string appendString { get; set; }

        public List<SearchSitesModel> getAllSites()
        {
            using (var db = new KYCAIS_DEVEntities())
            {
                return db.search_sites
                    .AsNoTracking()
                    .Select(s => new SearchSitesModel
                    {
                        id = s.id,
                        name = s.name,
                        url = s.url,
                        source = s.source,
                        appendString = s.appendString
                    })
                    .OrderBy(q => q.id)
                    .ToList();
            }
        }

    }
}
