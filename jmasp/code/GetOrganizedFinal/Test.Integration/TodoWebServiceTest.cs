/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using GetOrganized.Common;
using NUnit.Framework;
using System.Linq;

namespace Test.Integration
{
    [TestFixture]
    public class TodoWebServiceTest
    {
        [Test]
        public void Should_Authentication()
        {
            var response = Authenticate();

            Assert.AreEqual(1, response.Cookies.Count);
            Assert.AreEqual(".ASPXAUTH", response.Cookies[0].Name);
        }


        [Test]
        public void Should_Get_List_Of_Todos_As_XML()
        {
            var authenticateResponse = Authenticate(); 

            var responseWithXML =
              WebServiceUtil.SendWebRequest("http://localhost:1901/Todo/", string.Empty,
              "text/xml", authenticateResponse.Cookies[0]);

            var xmlReader = XmlReader.Create(responseWithXML.GetResponseStream());
            XDocument todoDoc = XDocument.Load(xmlReader);

            Assert.AreEqual("ArrayOfTodo", todoDoc.Root.Name.ToString());
            Assert.AreEqual("Todo", todoDoc.Root.Elements("Todo").First().Name.ToString());
            Assert.AreEqual("Title", todoDoc.Root.Elements("Todo").Elements("Title")
                .First().Name.ToString());
            Assert.AreEqual("Id", todoDoc.Root.Elements("Todo").Elements("Id")
                .First().Name.ToString());
        }

        [Test]
        public void Should_Send_Xml_To_Create_Todo()
        {
            var xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("todo", new XElement("title", "foo")));

            string xml = xdoc.Declaration + xdoc.ToString(SaveOptions.None);

            var authRequest = Authenticate();
            var xmlRequest = WebServiceUtil.SendWebRequest("http://localhost:1901/Todo/CreateWithXml", 
                xml, "text/xml", authRequest.Cookies[0]);

            var xmlReader = XmlReader.Create(xmlRequest.GetResponseStream());
            XDocument todoDoc = XDocument.Load(xmlReader);

            Assert.AreEqual("Todo", todoDoc.Root.Name.ToString());
            Assert.AreEqual("foo" , todoDoc.Root.Element(XName.Get("Title" )).Value);
        }


        private static HttpWebResponse Authenticate()
        {
            return WebServiceUtil.AuthenticateWithForms("jonathan", "password",
                    "http://localhost:1901/Account/LogOn");    
        }
    }
}