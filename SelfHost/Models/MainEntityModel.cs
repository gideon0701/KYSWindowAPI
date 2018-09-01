using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    public class MainEntityModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SubEntityModel> subEntities { get; set; }

        public bool isAvailable(string name)
        {
            using (var db = new KYCAIS_DEVEntities())
            {
                return db.mainEntities.Any((q => q.name.ToLower().Contains(name.ToLower())));
            }
        }
        public MainEntityModel getEntity(string name)
        {
            using (var db = new KYCAIS_DEVEntities())
            {
                return db.mainEntities
                    .AsNoTracking()
                    .Where(q => q.name.ToLower().Contains(name.ToLower()))
                    .Select(s => new MainEntityModel
                    {
                        id = s.id,
                        name = s.name,
                        subEntities = s.subEntities.Select(q => new SubEntityModel
                        {
                            id = q.id,
                            name = q.name
                        }).ToList()

                    })
                    .SingleOrDefault();
            }
        }

    }
}
