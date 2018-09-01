using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainEntityModel model = new MainEntityModel();
            model.subEntities = new List<SubEntityModel>();

            if (mainEntityModel.isAvailable(companyName))
            {
                return mainEntityModel.getEntity(companyName);
            }
            var dctSubMain = Utils.ner(StringUtil.getRelatedParties(companyName));
            model.name = companyName;
            foreach (var item in dctSubMain)
            {
                SubEntityModel subEntityModel = new SubEntityModel();

                subEntityModel.entityType_id = item.Value.Equals("PERSON") ? 2 : 1;
                subEntityModel.name = item.Key;

                model.subEntities.Add(subEntityModel);
            }

            return model;
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
