/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System.Web.Mvc;
using System.Web.Routing;

namespace GetOrganized.ViewHelpers
{
    public static class LinkHelper
    {
        public static string Link(this HtmlHelper helper, 
            string linkText, string url, object htmlAttributes)
        {
            var builder = new TagBuilder("a");

            builder.MergeAttributes(
                new RouteValueDictionary(htmlAttributes));
            builder.Attributes.Add("href", url);
            builder.InnerHtml = linkText;

            return builder.ToString();
        }
    }
}