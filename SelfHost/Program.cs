﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using HtmlAgilityPack;
using SimpleNetNlp;
using edu.stanford.nlp.ie.crf;

namespace SelfHost
{
 
    class Program
    {

        static void Main(string[] args)
        {



            var config = new HttpSelfHostConfiguration("http://localhost:23123");

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            try
            {
                using (HttpSelfHostServer server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    Console.WriteLine(new Sentence("bad").Sentiment);
                    Console.Clear();
                    Console.WriteLine("API is running at...");
                    Console.Write(Utils.GetLocalIPAddress());
                    Console.WriteLine(":23123");
                    Console.WriteLine("Press Enter to quit.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
