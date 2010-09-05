/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web.Mvc;
using GetOrganized.Models;

namespace GetOrganized.ViewHelpers
{
    public static class ColorDropDownHelper
    {
        public static string Topic(string name, List<Topic> options)
        {
            var select = new TagBuilder("select");
            select.MergeAttribute("style", "background-color: transparent;");
            select.MergeAttribute("name", name);
            select.GenerateId(name);

            var optionBuilder = new StringBuilder();

            foreach (var option in options)
            {
                var optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", option.Id.ToString());
                optionTag.MergeAttribute("style", 
                    "color: white; background-color: " + 
                    ColorTranslator.ToHtml(option.Color));
                optionTag.InnerHtml = option.Name;
                
                optionBuilder.Append(optionTag.ToString(TagRenderMode.Normal));
            }
            
            select.InnerHtml = optionBuilder.ToString();
            
            return select.ToString(TagRenderMode.Normal);
        }
    }
}