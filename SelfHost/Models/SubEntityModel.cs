using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    public class SubEntityModel
    {
        public int id { get; set; }
        public int? mainEntity_id { get; set; }
        public int? entityType_id { get; set; }
        public string name { get; set; }

    }
}
