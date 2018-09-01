using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web.Http;
using SimpleNetNlp;
using HtmlAgilityPack;

namespace SelfHost
{
    public class ResearchController : ApiController
    {
        MainEntityModel mainEntityModel = new MainEntityModel();
        /// <summary>
        /// Get the MainEntityModel
        /// </summary>
        public MainEntityModel GetList(string companyName) {
            if (mainEntityModel.isAvailable(companyName))
            {
                return mainEntityModel.getEntity(companyName);
            }

            return mainEntityModel.getEntity(companyName);
        }

        /// <summary>
        /// Return Sentiment Model
        /// </summary>
        /// <param name="name"></param>
        public void GetResult(string name)
        {

        }
    }
}
