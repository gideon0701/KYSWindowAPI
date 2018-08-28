

namespace SelfHost.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using SimpleNetNlp;
    using HtmlAgilityPack;
    public class TestController : ApiController
    {
        
            public string Get()
            {
                 return "Test";
            }
    }
}
