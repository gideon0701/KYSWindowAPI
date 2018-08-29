using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost.Utils
{
    class DownloadFileUtil
    {
        public static void downloadFile(string _downloadLink, string _downloadPath, string _fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(_downloadLink, _downloadPath + _fileName);

            }
        }
    }
}
