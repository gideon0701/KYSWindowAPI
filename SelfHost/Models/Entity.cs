using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    public class Entity
    {
        public string CompanyName { get; set; }
        public List<string> Links { get; set; }
        public List<string> LinkSentiments { get; set; }
        public int RiskScore { get; set; }

    }
}
