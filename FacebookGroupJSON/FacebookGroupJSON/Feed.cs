using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookGroupJSON
{
    class Feed
    {
        #region Private Fields

        private string _title;
        private string _link;
        private string _self;
        private DateTime _updated;
        private string _icon;
        private List<FeedEntry> _feedEntries;

        #endregion

        public Feed(string title, string link, string self, DateTime updated, string icon, List<FeedEntry> feedEntries)
        {
            _title = title;
            _link = link;
            _self = self;
            _updated = updated;
            _icon = icon;
            _feedEntries = feedEntries;
        }
    }
}
