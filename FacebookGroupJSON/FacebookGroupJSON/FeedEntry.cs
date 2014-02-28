using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookGroupJSON
{
    /// <summary>
    /// Rootobject class with the data
    /// </summary>
    public class Rootobject
    {
        public Responsedata responseData { get; set; }
        public object responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    /// <summary>
    /// Response data, holding results
    /// </summary>
    public class Responsedata
    {
        public Result[] results { get; set; }
        public Cursor cursor { get; set; }
    }

    /// <summary>
    /// Cursor
    /// </summary>
    public class Cursor
    {
        public Page[] pages { get; set; }
        public string estimatedResultCount { get; set; }
        public int currentPageIndex { get; set; }
        public string moreResultsUrl { get; set; }
    }

    /// <summary>
    /// Page
    /// </summary>
    public class Page
    {
        public string start { get; set; }
        public int label { get; set; }
    }

    /// <summary>
    /// Result class wit the specific news attributes
    /// </summary>
    public class Result
    {
        public string GsearchResultClass { get; set; }
        public string clusterUrl { get; set; }
        public string content { get; set; }
        public string unescapedUrl { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string titleNoFormatting { get; set; }
        public string location { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string signedRedirectUrl { get; set; }
        public string language { get; set; }
        public Image image { get; set; }
        public Relatedstory[] relatedStories { get; set; }
    }

    /// <summary>
    /// Image class
    /// </summary>
    public class Image
    {
        public string url { get; set; }
        public string tbUrl { get; set; }
        public string originalContextUrl { get; set; }
        public string publisher { get; set; }
        public int tbWidth { get; set; }
        public int tbHeight { get; set; }
    }

    /// <summary>
    /// Related stories class to get the related stories of a news item
    /// </summary>
    public class Relatedstory
    {
        public string unescapedUrl { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string titleNoFormatting { get; set; }
        public string location { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string signedRedirectUrl { get; set; }
        public string language { get; set; }
    }


}
