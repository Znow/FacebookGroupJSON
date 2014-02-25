using System;
using System.Collections;//.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FacebookGroupJSON
{
    public class FeedParser
    {
        public static void ParseJsonFromURL(string url)
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

            //using (var webClient = new System.Net.WebClient())
            //{
            //    var json = webClient.DownloadString(url);

            //    var reader = new JsonTextReader(new StringReader(json));

            //    while (reader.Read())
            //    {
            //        if (reader.Value != null)
            //            Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
            //        else
            //            Console.WriteLine("Token: {0}", reader.TokenType);
            //    }
                
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
                    catch (Exception) {}
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }


                var feedEntry = _download_serialized_json_data<FeedEntry>(CONSTANTS.BASEQUERYURL + CONSTANTS.ACCESS_TOKEN);
            
        }
    }
}
