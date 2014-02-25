using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGroupJSON
{
    class FeedItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        private string QueryURL;

        public FeedItem(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public string getQueryURL()
        {
            return CONSTANTS.BASEQUERYURL + ID + CONSTANTS.ACCESS_TOKEN;
        }
    }
}
