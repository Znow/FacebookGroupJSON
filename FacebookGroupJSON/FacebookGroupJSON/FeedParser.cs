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
        /// <summary>
        /// Parse JSON content from a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Rootobject ParseJsonFromURL(string url)
        {
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
