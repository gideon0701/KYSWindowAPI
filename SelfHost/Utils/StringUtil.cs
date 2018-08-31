using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    class StringUtil
    {

        public static string FormatLink(string link)
        {

            return link.Substring(7).Split('&').First();
        }
    }
}
