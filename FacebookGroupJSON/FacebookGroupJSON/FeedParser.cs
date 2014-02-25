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

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);

                var reader = new JsonTextReader(new StringReader(json));

                while (reader.Read())
                {
                    if (reader.Value != null)
                        Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    else
                        Console.WriteLine("Token: {0}", reader.TokenType);
                }
                
            }

            
        }
    }
}
