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
        SearchSitesModel searchSitesModel;
        public CompanyModel GetCompany(string name)
        {
            companyModel = new CompanyModel();
            searchSitesModel = new SearchSitesModel();
            var lstSites = searchSitesModel.getAllSites();
            companyModel.CompanyName = name;
            companyModel.Links = new List<string>();
            companyModel.HeadlinesSentiment = new List<string>();
            companyModel.Headlines = new List<string>();
          
            foreach (var site in lstSites)
            {
                var strNewsUrl = site.url;
                var strQuery = site.appendString;
                var strClientName = name;
                var strUrl = strNewsUrl + strQuery + strClientName;
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(strUrl);

                var xpath = "//*[self::h2 or self::h3]";
                var strCmpr = site.name.Equals("Google") ? "r" : "result";
                var results = htmlDoc.DocumentNode.SelectNodes(xpath)
                    .Where(node => node.GetAttributeValue("class", "").Contains(strCmpr))
                    .Select(node => node.FirstChild)
                    .ToList();

                foreach (var res in results)
                {
                    var headLines = res.InnerText;
                    var link = res.Attributes["href"].Value;
                    link = link.Contains("http") ? link : strNewsUrl + link;

                    companyModel.Headlines.Add(headLines);
                    companyModel.Links.Add(link);
                    companyModel.HeadlinesSentiment.Add(new Sentence(headLines).Sentiment.ToString());
                }
            }

            companyModel.RiskScore = 123;
            return companyModel;
        }

    }
}