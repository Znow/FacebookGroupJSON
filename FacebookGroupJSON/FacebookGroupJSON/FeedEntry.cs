using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookGroupJSON
{
    public class FeedEntry<T> where T : new()
    {
        #region Public Fields

        public string _title;
        public string _id;
        public string _alternate;
        public string[] _categories;
        public DateTime _published;
        public DateTime _updated;
        public string _authorName;
        public string _verb;
        public string _target;
        public string _objects;
        public string _comments;
        public string _likes;
        public string _content;

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
        public List<FeedEntry<T>> GetFeedEntriesByFeed()
        {
            return new List<FeedEntry<T>>();
        }
        #endregion



    }
}
