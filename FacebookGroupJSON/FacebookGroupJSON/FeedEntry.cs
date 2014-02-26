using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookGroupJSON
{

    public class Rootobject
    {
        public Responsedata responseData { get; set; }
        public object responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class Responsedata
    {
        public Result[] results { get; set; }
        public Cursor cursor { get; set; }
    }

    public class Cursor
    {
        public Page[] pages { get; set; }
        public string estimatedResultCount { get; set; }
        public int currentPageIndex { get; set; }
        public string moreResultsUrl { get; set; }
    }

    public class Page
    {
        public string start { get; set; }
        public int label { get; set; }
    }

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

    public class Image
    {
        public string url { get; set; }
        public string tbUrl { get; set; }
        public string originalContextUrl { get; set; }
        public string publisher { get; set; }
        public int tbWidth { get; set; }
        public int tbHeight { get; set; }
    }

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
