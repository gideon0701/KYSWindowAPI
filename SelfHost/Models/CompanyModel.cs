using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SelfHost
{
    public class CompanyModel
    {
        public string CompanyName { get; set; }
        public List<string> Links { get; set; }
        public List<string> HeadlinesSentiment { get; set; }
        public List<string> Headlines { get; set; }
        public string HeadlineNER { get; set; }
        public int RiskScore { get; set; }
       
    }
}
