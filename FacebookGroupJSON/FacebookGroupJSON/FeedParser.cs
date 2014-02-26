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

        // http://www.codeproject.com/Tips/397574/Use-Csharp-to-get-JSON-Data-from-the-Web-and-Map-i
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = webClient.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }


            //var feedEntry = _download_serialized_json_data<FeedEntry<T>>(CONSTANTS.BASEQUERYURL + CONSTANTS.ACCESS_TOKEN);

        }
    }
}
