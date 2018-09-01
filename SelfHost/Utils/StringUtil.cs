using HtmlAgilityPack;
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

        public static List<string> getRelatedParties(string name) {
            List<string> lstStr = new List<string>();
            var strNewsUrl = "https://www.google.com.ph";
            var strQuery = "/search?q=";
            var strClientName = name + " board of directors";
            var strUrl = strNewsUrl + strQuery + strClientName;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(strUrl);

            var xpath = $"//h3[@class='r']";
            var tests = htmlDoc.DocumentNode.InnerHtml;
            var results = htmlDoc.DocumentNode.SelectNodes(xpath);

            if (results != null)
            {
                var res = results.Select(node => node.ChildNodes["a"]).FirstOrDefault();
                var str = res.Attributes["href"].Value;
                var link = str.StartsWith("/url") ? FormatLink(str) : str;

                link = link.Contains("http") ? link : strNewsUrl + link;
                web = new HtmlWeb();
                var htmlDoc2 = web.Load(link);

                var nodes = htmlDoc2.DocumentNode.SelectNodes("//p//a");
                nodes.RemoveAt(0);
                foreach (var node in nodes)
                {
                    lstStr.Add(node.InnerText);
                }

            }

            return lstStr;
        }
    }
}
