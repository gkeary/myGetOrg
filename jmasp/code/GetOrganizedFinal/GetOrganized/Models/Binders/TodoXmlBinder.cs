/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System;
using System.IO;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace GetOrganized.Models.Binders
{
    public class TodoXmlBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            using (var reader= new StreamReader(controllerContext.RequestContext.HttpContext.Request.InputStream))
            {
                var rawXml = XmlReader.Create(reader);
                XDocument doc = XDocument.Load(rawXml);
                var todoTitle = doc.Root.Element(XName.Get("title")).Value;
                
                var todo = new Todo();
                todo.Title = todoTitle;
                //bindingContext.Model = todo;
                //? why both set to context and return?
                return todo;
            }
        }
    }
}