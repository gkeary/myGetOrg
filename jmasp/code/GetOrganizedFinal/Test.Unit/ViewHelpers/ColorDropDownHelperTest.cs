/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;
using System.Drawing;
using GetOrganized.Models;
using GetOrganized.ViewHelpers;
using NUnit.Framework;

namespace Test.Unit.ViewHelpers
{
    [TestFixture]
    public class ColorDropDownHelperTest
    {
        [Test]
        public void Should_Render_Colored_DropDown_Markup()
        {
	        var workTopic = new List<Topic> { new Topic {Id=1, 
		        Name="Work", Color= Color.Red} };
	        Assert.AreEqual("<select id=\"Topic_Id\" " +
              "name=\"Topic.Id\" style=\"background-color: transparent;\">"  +
			  "<option " +      
              "style=\"color: white; background-color: Red\" " +
              "value=\"1\">Work</option></select>", 
		        ColorDropDownHelper.Topic("Topic.Id", workTopic));
        }
    }
}