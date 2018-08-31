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

            companyModel.CompanyName = name;
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
                        var str = res.Attributes["href"].Value;
                        var link = str.StartsWith("/url") ? StringUtil.FormatLink(str) : str;
                        link = link.Contains("http") ? link : strNewsUrl + link;

                        companyModel.Headlines.Add(headLines);
                        companyModel.Links.Add(link);
                        companyModel.HeadlinesSentiment.Add(new Sentence(headLines).Sentiment.ToString());
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


            var strNewsUrl = "https://www.icij.org";
            var strQuery = "/search/";
            var strClientName = test;
            var strUrl = strNewsUrl + strQuery + strClientName;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(strUrl);

            var strElement = "div";
            var strCmpr = "title";
            var xpath = $"//p[@class='Post__category']";
            var tests = htmlDoc.DocumentNode.InnerHtml;
            var results = htmlDoc.DocumentNode.SelectNodes(xpath);
            
            if (results != null)
            {
                var lstRes = results.Select(node => node.ChildNodes["a"]).ToList();
                foreach (var res in lstRes)
                {
                    var headLines = res.ChildNodes["h3"].InnerText;
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