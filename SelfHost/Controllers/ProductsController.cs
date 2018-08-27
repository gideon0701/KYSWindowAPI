namespace SelfHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using SimpleNetNlp;
    using HtmlAgilityPack;
    public class ProductsController : ApiController
    {
        Entity CompanyEntity = new Entity { };
        public Entity GetCompany(string name)
        {
            CompanyEntity.CompanyName = name;
            Console.WriteLine(CompanyEntity.CompanyName);


            var html = @"http://google.com/search?q=";
            var search = html + name;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(search);

            var results = htmlDoc.DocumentNode.Descendants("h3").Where(node => node.GetAttributeValue("class", "").Equals("r")).ToList();

            List<string> links = new List<string>();
            List<string> linkSentiments = new List<string>(); 
            int i = 0;
            foreach (var res in results)
            {
                links.Add(res.Descendants("a").FirstOrDefault().ChildAttributes("href").First().Value.Substring(7).Split('&').First());
                linkSentiments.Add(new Sentence(links[i]).Sentiment.ToString());
                Console.WriteLine(links[i]);
                Console.WriteLine(linkSentiments[i]);

                i++;
            }

            CompanyEntity.Links = links;
            CompanyEntity.LinkSentiments = linkSentiments;
            CompanyEntity.RiskScore = 123;
            return CompanyEntity;
        }

    }
}