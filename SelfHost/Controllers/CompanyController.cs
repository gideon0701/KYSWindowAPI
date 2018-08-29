namespace SelfHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using SimpleNetNlp;
    using HtmlAgilityPack;
    public class CompanyController : ApiController
    {
        CompanyModel companyModel;
        public CompanyModel GetCompany(string name)
        {

            companyModel = new CompanyModel();

            companyModel.CompanyName = name;
            companyModel.Links = new List<string>();
            companyModel.HeadlinesSentiment = new List<string>();
            companyModel.Headlines = new List<string>();

            var strNewsUrl = "https://www.reuters.com/";
            var strQuery = "search/news?blob=";
            var strClientName = name;

            var strUrl = strNewsUrl + strQuery + strClientName;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(strUrl);

            var xpath = "//*[self::h1 or self::h2 or self::h3 or self::h4]";
            var results = htmlDoc.DocumentNode.SelectNodes(xpath)
                .Where(node => node.GetAttributeValue("class", "").Contains("result"))
                .Select(node => node.FirstChild)
                .ToList();

            foreach (var res in results)
            {
                var headLines = res.InnerText;
                Console.WriteLine(new Sentence(headLines).Sentiment);
                companyModel.Headlines.Add(headLines);
                companyModel.HeadlinesSentiment.Add(new Sentence(headLines).Sentiment.ToString());
            }


            companyModel.RiskScore = 123;
            return companyModel;
        }

    }
}