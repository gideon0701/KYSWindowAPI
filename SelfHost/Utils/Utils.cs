using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using edu.stanford.nlp.ie.crf;

namespace SelfHost
{
    class Utils
    {
        public static void DownloadFile(string _downloadLink, string _downloadPath, string _fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(_downloadLink, _downloadPath + _fileName);

            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static Dictionary<string,string> ner(string content)
        {


            Dictionary<string, string> EntityDict = new Dictionary<string, string>();
            // Path to the folder with classifiers models
            var jarRoot = @"C:\Users\Gideon\Documents\stanford-ner-2017-06-09";
            var classifiersDirecrory = jarRoot + @"\classifiers";
            // Loading 7 class classifier model
            var classifier = CRFClassifier.getClassifierNoExceptions(
                classifiersDirecrory + @"\english.muc.7class.distsim.crf.ser.gz");
            // Applying ner tagging and saving to xml string
            var ner = classifier.classifyWithInlineXML(content);
            // Adding root  
            ner = "<root>" + ner + "</root>";
            // Converting to Xml document
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(ner);
            // Iterating inside Xml Document
            foreach (XmlNode item in xmlDoc.ChildNodes[0].ChildNodes)
            {
                var entity = item.Name;

                if (entity == "ORGANIZATION")
                {
                    EntityDict.Add(item.InnerText, entity);
                }
                if (entity == "LOCATION")
                {
                    EntityDict.Add(item.InnerText, entity);

                }
                if (entity == "PERSON")
                {
                    EntityDict.Add(item.InnerText, entity);

                }
                if (entity == "MONEY")
                {
                    EntityDict.Add(item.InnerText, entity);

                }
                if (entity == "DATE")
                {
                    EntityDict.Add(item.InnerText, entity);
                }
                if (entity == "PERCENT")
                {
                    EntityDict.Add(item.InnerText, entity);
                }
                if (entity == "TIME")
                {
                    EntityDict.Add(item.InnerText, entity);

                }
            }

          
            return EntityDict;
        }

    }
}
