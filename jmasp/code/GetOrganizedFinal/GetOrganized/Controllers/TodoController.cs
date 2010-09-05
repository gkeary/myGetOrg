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
using System.Web.Mvc;
using GetOrganized.Gateway;
using GetOrganized.Models;
using GetOrganized.Models.Binders;
using GetOrganized.Models.Validator;
using GetOrganized.Persistence;
using GetOrganized.Persistence.Repositories;
using MvcContrib.ActionResults;

namespace GetOrganized.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly BloggerGateway gateway;
        private readonly ThoughtRepository thoughtRepository;
        private readonly TopicRepository topicRepository;
        private readonly TodoRepository repository;

        public TodoController(TodoRepository repository, BloggerGateway gateway, 
            ThoughtRepository thoughtRepository, TopicRepository topicRepository)
        {
            this.repository = repository;
            this.gateway = gateway;
            this.thoughtRepository = thoughtRepository;
            this.topicRepository = topicRepository;
        }

        //
        // GET: /Todo/

        public ActionResult Index()
        {
            ViewData["UserName"] = User.Identity.Name;

            ViewData.Model = repository.GetAll();

            if (Request.Headers["Content-Type"] == "text/xml")
                return new XmlResult(ViewData.Model);
            else
                return View();
        }

        //
        // GET: /Todo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Todo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Todo/Create
        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Create([Bind(Exclude = "Id")] Todo todo)
        {
            todo.Validate(ModelState);

            if (ModelState.IsValid)
            {
                CreateTodo(todo);
                if (Request.IsAjaxRequest())
                    return Json(todo);
                return RedirectToAction("Index");
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(ModelState.ToList());
                else
                {
                    return View();
                }
            }
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult CreateWithXml([ModelBinder(typeof (TodoXmlBinder))] Todo todo)
        {
            Create(todo);
            return new XmlResult(todo);
        }


        //
        // GET: /Todo/Edit/somethingToDo
        public ActionResult Edit(string title)
        {
            ViewData.Model = repository.GetAll().Where(todo => todo.Title == title).First();
            return View();
        }


        //
        // POST: /Todo/Edit/somethingToDo

        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Edit(string oldTitle, Todo item)
        {
            try
            {
                Todo itemToEdit = repository.GetAll().Where(todo => todo.Title == oldTitle).First();

                itemToEdit = item;
                repository.SaveOrUpdate(itemToEdit);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/Delete/Title={name of todo}
        [AcceptVerbs(HttpVerbs.Post)]
        [Transaction]
        public ActionResult Delete(string title)
        {
            repository.Delete(
                repository.GetAll().Where(todo => todo.Title == title).First());

            if (Request.IsAjaxRequest())
                return new EmptyResult();

            return RedirectToAction("Index");
        }

        [Transaction]
        public ActionResult Convert(Thought thought, string outcome)
        {
            var newTodo = new Todo
                              {
                                  Title = thought.Name,
                                  Outcome = outcome,
                                  Topic = topicRepository.GetAll().
                                  Where(topic => topic.Id == thought.Topic.Id).First()
                              };
            CreateTodo(newTodo);

            var loadedThought = thoughtRepository.GetAll().Where(x => x.Id == thought.Id).First();

            thoughtRepository.Delete(loadedThought);

            return RedirectToAction("Process", "Thought");
        }

        public ActionResult BloggerAuthorized(string title, string token)
        {
            Todo todo = repository.GetAll().Where(x => x.Title == title).First();
            gateway.PublishAsDraft(todo, token);
            return Redirect("http://jonathanmccracken.blogspot.com");
        }

        public ActionResult PublishToBlogger(string title)
        {
            Todo todo = repository.GetAll().Where(x => x.Title == title).First();

            return Redirect(gateway.AuthenticateURL(todo.Title));
        }

        private void CreateTodo(Todo todo)
        {
            repository.SaveOrUpdate(todo);
            if (Session["SessionSummary"] == null)
                Session["SessionSummary"] = new SessionSummary();

            var summary = ((SessionSummary) Session["SessionSummary"]);
            summary.AddedTodos.Add(todo);
        }
    }
}