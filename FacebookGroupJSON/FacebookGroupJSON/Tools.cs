﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FacebookGroupJSON
{
    public class Tools
    {
        /// <summary>
        /// Strips HTML tags from the string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripTags(string input)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(input ?? "");
            return doc.DocumentNode.InnerText;
        }
    }
}
