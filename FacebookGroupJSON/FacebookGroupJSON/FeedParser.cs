using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FacebookGroupJSON
{
    public class FeedParser
    {
        public static Rootobject ParseJsonFromURL(string url)
        {
            string json2 = @"{
                'CPU': 'Intel',
                'PSU': '500W',
                'Drives': [
                  'DVD read/writer'
                  /*(broken)*/,
                  '500 gigabyte hard drive',
                  '200 gigabype hard drive'
                ]
            }";

            using (var webClient = new System.Net.WebClient())
            {
                // get the json from the URL
                var json = webClient.DownloadString(url);
                
                Rootobject ro = new Rootobject();

                // Try Deserialize the JSON from the value from the URL and return a Rootobject
                try
                {
                    ro = JsonConvert.DeserializeObject<Rootobject>(json);
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                }

                return ro;
            }
        }

    }
}
