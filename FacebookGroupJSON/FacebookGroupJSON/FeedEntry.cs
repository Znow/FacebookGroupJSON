using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookGroupJSON
{
    public class FeedEntry
    {

    }
}

public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public object coordinates { get; set; }
    public bool truncated { get; set; }
    public bool favorited { get; set; }
    public string created_at { get; set; }
    public string id_str { get; set; }
    public Entities entities { get; set; }
    public object in_reply_to_user_id_str { get; set; }
    public string text { get; set; }
    public object contributors { get; set; }
    public object in_reply_to_status_id_str { get; set; }
    public long id { get; set; }
    public int retweet_count { get; set; }
    public object geo { get; set; }
    public bool retweeted { get; set; }
    public object in_reply_to_user_id { get; set; }
    public string source { get; set; }
    public User user { get; set; }
    public object in_reply_to_screen_name { get; set; }
    public object place { get; set; }
    public object in_reply_to_status_id { get; set; }
}

public class Entities
{
    public Url[] urls { get; set; }
    public object[] hashtags { get; set; }
    public object[] user_mentions { get; set; }
}

public class Url
{
    public string expanded_url { get; set; }
    public string url { get; set; }
    public int[] indices { get; set; }
    public string display_url { get; set; }
}

public class User
{
    public string profile_sidebar_border_color { get; set; }
    public bool profile_background_tile { get; set; }
    public string profile_sidebar_fill_color { get; set; }
    public string name { get; set; }
    public object expanded_url { get; set; }
    public string location { get; set; }
    public string profile_image_url { get; set; }
    public string created_at { get; set; }
    public bool? follow_request_sent { get; set; }
    public bool is_translator { get; set; }
    public string profile_link_color { get; set; }
    public string id_str { get; set; }
    public Entities1 entities { get; set; }
    public bool contributors_enabled { get; set; }
    public int favourites_count { get; set; }
    public bool default_profile { get; set; }
    public string url { get; set; }
    public string profile_image_url_https { get; set; }
    public int id { get; set; }
    public int utc_offset { get; set; }
    public int listed_count { get; set; }
    public bool profile_use_background_image { get; set; }
    public string lang { get; set; }
    public int followers_count { get; set; }
    public string profile_text_color { get; set; }
    public bool _protected { get; set; }
    public string time_zone { get; set; }
    public bool geo_enabled { get; set; }
    public string profile_background_image_url_https { get; set; }
    public bool? notifications { get; set; }
    public string description { get; set; }
    public bool verified { get; set; }
    public string profile_background_color { get; set; }
    public bool default_profile_image { get; set; }
    public int friends_count { get; set; }
    public string profile_background_image_url { get; set; }
    public int statuses_count { get; set; }
    public object display_url { get; set; }
    public string screen_name { get; set; }
    public bool show_all_inline_media { get; set; }
    public bool? following { get; set; }
}

public class Entities1
{
    public object[] urls { get; set; }
    public object[] hashtags { get; set; }
    public object[] user_mentions { get; set; }
}
