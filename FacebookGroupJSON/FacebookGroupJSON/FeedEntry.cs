using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookGroupJSON
{
    class FeedEntry
    {
        #region Private Fields

        private string _title;
        private string _id;
        private string _alternate;
        private string[] _categories;
        private DateTime _published;
        private DateTime _updated;
        private string _authorName;
        private string _verb;
        private string _target;
        private string _objects;
        private string _comments;
        private string _likes;
        private string _content;

        #endregion Fields

        #region Constructor

        public FeedEntry(string title, string id, string alternate, string[] categories, DateTime published, DateTime updated, string authorName, string verb, string target, string objects, string comments, string likes, string content)
        {
            _title = title;
            _id = id;
            _alternate = alternate;
            _categories = categories;
            _published = published;
            _updated = updated;
            _authorName = authorName;
            _verb = verb;
            _target = target;
            _objects = objects;
            _comments = comments;
            _likes = likes;
            _content = content;
        }

        #endregion

        #region Methods
        public List<FeedEntry> GetFeedEntriesByFeed()
        {
            return new List<FeedEntry>();
        }
        #endregion



    }
}
