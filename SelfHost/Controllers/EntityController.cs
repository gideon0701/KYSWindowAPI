using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNetNlp;
using HtmlAgilityPack;
using System.Net;
using System.Web.Http;
namespace SelfHost
{
    class EntityController : ApiController
    {
        Entity CompanyEntity = new Entity {  };
        public Entity Company()
        {

            //CompanyEntity.CompanyName = name;
            //var strNewsUrl = "https://www.reuters.com/";
            //var strQuery = "search/news?blob=";
            //var strUrl = strNewsUrl + strQuery + "unionbank";

            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(strUrl);
            //var xpath = "//*[self::h1 or self::h2 or self::h3 or self::h4]";
            //var results = htmlDoc.DocumentNode.SelectNodes(xpath)
            //    .Where(node => node.GetAttributeValue("class", "").Contains("result"))
            //    .Select(node => node.FirstChild)
            //    .ToList();

            //foreach (var item in results)
            //{
            //    CompanyEntity.Links.Add(item.InnerText);
            //    var sent = new Sentence(item.InnerText).Sentiment.ToString();
            //    Console.WriteLine(sent);
            //    CompanyEntity.LinkSentiments.Add(sent);
            //}
            //CompanyEntity.senti = new Sentence("This is so bad!").Sentiment.ToString();
            //CompanyEntity.RiskScore = 123;
            return CompanyEntity;
        }

    }
}
