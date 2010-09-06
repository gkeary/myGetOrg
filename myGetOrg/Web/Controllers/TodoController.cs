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

        public ActionResult  Delete(string p)
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
    }
}