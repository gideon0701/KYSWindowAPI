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

            companyModel.CompanyName = name + " news";
            companyModel.Links = new List<string>();
            companyModel.HeadlinesSentiment = new List<string>();
            companyModel.Headlines = new List<string>();

            var lstSites = searchSitesModel.getAllSites();
            foreach (var site in lstSites)
            {
                var strNewsUrl = site.url;
                var strQuery = site.appendString;
                var strClientName = name;
                var strUrl = strNewsUrl + strQuery + strClientName;
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(strUrl);

                var arrSource = site.source.Split(',');
                var strElement = arrSource[0];
                var strClass = arrSource[1];

                var strHeadlineElem = arrSource[2];
                int intCnt = strHeadlineElem.Count();

                var xpath = $"//{strElement}[@class='{strClass}']";
                var results = htmlDoc.DocumentNode.SelectNodes(xpath);

                if (results != null)
                {
                    var lstRes = results.Select(node => node.ChildNodes["a"]).ToList();

                    foreach (var res in lstRes)
                    {
                        var headLines = intCnt <= 0 ? res.InnerText : res.ChildNodes[strHeadlineElem].InnerText;
                        var strSenti = new Sentence(headLines).Sentiment.ToString();
                        var str = res.Attributes["href"].Value;
                        var link = str.StartsWith("/url") ? StringUtil.FormatLink(str) : str;
                        link = link.Contains("http") ? link : strNewsUrl + link;

                        if (strSenti.Equals("Negative"))
                        {
                            companyModel.Headlines.Add(headLines);
                            companyModel.Links.Add(link);
                            companyModel.HeadlinesSentiment.Add(strSenti);
                        }
                    }
                }

            }

            companyModel.RiskScore = 123;
            return companyModel;
        }

        public CompanyModel GetTest(string test)
        {
            companyModel = new CompanyModel();
            searchSitesModel = new SearchSitesModel();

            companyModel.CompanyName = test;
            companyModel.Links = new List<string>();
            companyModel.HeadlinesSentiment = new List<string>();
            companyModel.Headlines = new List<string>();


            var strNewsUrl = "https://www.google.com.ph";
            var strQuery = "/search?q=";
            var strClientName = test + " board of directors";
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
                var link = str.StartsWith("/url") ? StringUtil.FormatLink(str) : str;
                link = link.Contains("http") ? link : strNewsUrl + link;
                web = new HtmlWeb();
                var htmlDoc2 = web.Load(link);

                var nodes = htmlDoc2.DocumentNode.SelectNodes("//p//a");
                foreach (var node in nodes)
                {
                    companyModel.Headlines.Add(node.InnerText);
                }

            }

            companyModel.RiskScore = 123;
            return companyModel;
        }

    }
}