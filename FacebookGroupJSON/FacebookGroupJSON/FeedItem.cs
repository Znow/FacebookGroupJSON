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
        public string Search { get; set; }
        public string SearchNoWhiteSpaces { get; set; }
        public override string ToString() { return this.Search; }
        #endregion'

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="search"></param>
        /// <param name="searchNoWhiteSpaces"></param>
        public FeedItem(string search, string searchNoWhiteSpaces)
        {
            Search = search;
            SearchNoWhiteSpaces = searchNoWhiteSpaces;
        }

        #endregion
    }
}
