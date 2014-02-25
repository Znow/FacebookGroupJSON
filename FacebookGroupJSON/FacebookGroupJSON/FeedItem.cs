using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGroupJSON
{
    public class FeedItem
    {

        #region Fields
        public string ID { get; set; }
        public string Name { get; set; }
        private string QueryURL;
        public override string ToString() { return this.Name; }
        #endregion'

        #region Constructor
        public FeedItem(string id, string name)
        {
            ID = id;
            Name = name;
        }
        #endregion

        #region Methods
        public string getQueryURL()
        {
            return CONSTANTS.BASEQUERYURL + ID + CONSTANTS.ACCESS_TOKEN;
        }
        #endregion
    }
}
