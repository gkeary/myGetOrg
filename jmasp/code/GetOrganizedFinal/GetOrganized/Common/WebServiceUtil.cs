/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GetOrganized.Common
{
    public class WebServiceUtil
    {
        public static HttpWebResponse AuthenticateWithForms(string username,
          string password, string url)
        {
            string parameters = "&userName=" + username + "&password=" + password + "&rememberMe=true";
            return SendWebRequest(url, parameters, "application/x-www-form-urlencoded");
        }

        public static HttpWebResponse SendWebRequestWithAuthToken(string uri, string parameters,
          string contentType, string token, params Cookie[] cookies)
        {
            HttpWebRequest request = CreateRequest(uri, cookies, contentType, parameters);
            if (token != null)
                request.Headers.Add("Authorization", "AuthSub token=\"" + token + "\"");
            WriteRequest(parameters, request);
            return (HttpWebResponse)request.GetResponse();
        }

        public static HttpWebResponse SendWebRequest(string uri, string parameters,
          string contentType, params Cookie[] cookies)
        {
            HttpWebRequest request = CreateRequest(uri, cookies, contentType, parameters);

            WriteRequest(parameters, request);
   
            return (HttpWebResponse)request.GetResponse();
        }


        private static void WriteRequest(string parameters, HttpWebRequest request)
        {
            if (string.IsNullOrEmpty(parameters)) return;

            using (var requestWriter = new StreamWriter(request.GetRequestStream(),
                                                        System.Text.Encoding.ASCII))
            {
                requestWriter.Write(parameters);
            }
        }

        private static HttpWebRequest CreateRequest(string uri, Cookie[] cookies, string contentType, string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.CookieContainer = new CookieContainer();
            if (cookies != null)
                cookies.ToList().ForEach(cookie => request.CookieContainer.Add(cookie));

            request.AllowAutoRedirect = false;
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = parameters.Length;
            return request;
        }
    }

}