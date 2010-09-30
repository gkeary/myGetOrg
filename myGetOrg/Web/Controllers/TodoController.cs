using System;
using System.Web.Mvc;
using Web.Models;
using GetOrganized.Web.Models;

namespace GetOrganized.Web.Controllers
{
    public class TodoController : Controller
    {
        //
        // GET: /Todo/

        public ActionResult Index()
        {
            ViewData.Model = Todo.ThingsToBeDone;
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

        public ActionResult Create()
        {
            return View();
        }


        // POST: /Todo/Create

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            try
            {
                Todo.ThingsToBeDone.Add(todo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string p)
        {
            Todo.ThingsToBeDone.RemoveAll(t => t.Title == p);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string title)
        {
            ViewData.Model = Todo.ThingsToBeDone.Find(todo => todo.Title == title);
            return View();
        }

        // POST:  /Todo/Edit/somethingToDo

        [HttpPost]
        public ActionResult Edit(string oldTitle, Todo item)
        {
            try
            {
                Todo.ThingsToBeDone.RemoveAll(aTodo => aTodo.Title == oldTitle);
                Todo.ThingsToBeDone.Add(item);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Convert(Thought thought, string outcome)
        {
            var newToDo =
                new Todo
                  {
                      Title = thought.Name,
                      Outcome = outcome,
                      Topic = Topic.Topics.Find(t =>
                          t.Id == thought.Topic.Id
                      )
                  };
            CreateTodo(newToDo);

            Thought.Thoughts.RemoveAll(
                thoughtToRemove =>
                thoughtToRemove.Name == thought.Name);
            return RedirectToAction("Process", "Thought");
        }

        private void CreateTodo(Todo todo)
        {
            Todo.ThingsToBeDone.Add(todo);

            if (Session["SessionSummary"] == null)
                Session["SessionSummar"] = new SessionSummary();

            var summary = ((SessionSummary)Session["SessionSummary"]);
            summary.AddedTodos.Add(todo);
        }
    }
}