using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGroupJSON
{
    class FeedItem
    {
        private string BaseQueryURL = "https://www.facebook.com/feeds/page.php?format=rss20&id=";
        public string ID { get; set; }
        public string Name { get; set; }
        public string QueryURL { get { return BaseQueryURL + ID; } set; }


        public FeedItem(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
