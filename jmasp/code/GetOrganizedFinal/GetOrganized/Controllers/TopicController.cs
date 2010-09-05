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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GetOrganized.Models;
using GetOrganized.Persistence;
using GetOrganized.Persistence.Repositories;

namespace GetOrganized.Controllers
{
    public class TopicController : Controller
    {
        private readonly TopicRepository topicRepository;

        public TopicController(TopicRepository topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        //
        // GET: /Topic/

        public ActionResult Index()
        {
            ViewData.Model = topicRepository.GetAll();
            return View();
        }

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Topic/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Topic/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var newTopic = new Topic();
                newTopic.Name = collection["Name"];
                newTopic.Color = ColorTranslator.FromHtml("#" + collection["Color"]);
                
                topicRepository.SaveOrUpdate(newTopic);

                TempData["message"] = "Your topic has been added successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Topic/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
