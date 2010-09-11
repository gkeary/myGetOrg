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
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetOrganized.Models;
using GetOrganized.Persistence;
using GetOrganized.Persistence.Repositories;

namespace GetOrganized.Controllers
{
    public class ThoughtController : Controller
    {
        private readonly ThoughtRepository thoughtRepository;
        private readonly TopicRepository topicRepository;

        public ThoughtController(ThoughtRepository thoughtRepository, TopicRepository topicRepository)
        {
            this.thoughtRepository = thoughtRepository;
            this.topicRepository = topicRepository;
        }


        //
        // GET: /Thought/

        public ActionResult Index()
        {
            ViewData.Model = thoughtRepository.GetAll();
            return View();
        }

        //
        // GET: /Thought/Details/5

        public ActionResult Details(int id)
        {
            return View(thoughtRepository.GetAll().Where
                            (x => x.Id == id).First());
        }

        //
        // GET: /Thought/FindDetails?nameOfThought={name}

        public ActionResult FindDetails(string nameOfThought)
        {
            var thought = thoughtRepository.GetAll().Where
                (x => x.Name == nameOfThought).First();
            
            return RedirectToAction("Details", 
                new { id = thought.Id });
        }

        //
        // GET: /Thought/Create

        public ActionResult Create()
        {
            ViewData["Topics"] = topicRepository.GetAll();
            return View();
        }

        //
        // POST: /Thought/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Create(Thought newThought)
        {
            var topics = topicRepository.GetAll();
            newThought.Topic = topics.
                Where(topic => topic.Id == newThought.Topic.Id).First();

            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["ImageAttachment"];
                if (file.ContentLength != 0)
                {
                    int randomNumber = new Random().Next(100000, Int32.MaxValue);
                    string imgUrl = "UserContent/" + randomNumber + "-" + file.FileName;
                    file.SaveAs(Server.MapPath("~/UserContent") + "/" + randomNumber + "-" + file.FileName);
                    newThought.ImageAttachment = imgUrl;
                }
            }

            thoughtRepository.SaveOrUpdate(newThought);

            return RedirectToAction("Index");
        }

        //
        // GET: /Thought/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Thought/Edit/5

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

        //
        // GET: /Thought/Process

        public ActionResult Process()
        {
            IEnumerable<Thought> unprocessedThoughts =
                thoughtRepository.GetAll().Where(x => x.IsASomeday == false);

            if (unprocessedThoughts.Count() == 0)
                return Redirect("Index");

            ViewData.Model = unprocessedThoughts.First();
            return View();
        }

        //
        // GET: /Thought/Download/5

        public FilePathResult Download(int id)
        {
            Thought thought = thoughtRepository.GetAll().Where(x => x.Id == id).First();

            //actual download, not sure about mime type
            return File("~/" + thought.ImageAttachment, "application/octet-stream",
                        Path.GetFileName(thought.ImageAttachment)
                            .Split(new[] {'-'}, 2)[1]);
        }

        //
        // POST: /Thought/MakeASomeday

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult MakeASomeday(Thought aThoughtToDoSomeday)
        {
            aThoughtToDoSomeday.IsASomeday = true;
            thoughtRepository.SaveOrUpdate(aThoughtToDoSomeday);

            return RedirectToAction("Process");
        }

        public ActionResult Search(string q)
        {
            var searchResults = thoughtRepository.GetAll().Where(
                thought => thought.Name.ToLower().Contains(q.ToLower()));

            var autocompleteResults = String.Join("\n", 
                searchResults.ToList().ConvertAll(g => g.Name).ToArray());

            return Content(autocompleteResults);
        }
    }
}