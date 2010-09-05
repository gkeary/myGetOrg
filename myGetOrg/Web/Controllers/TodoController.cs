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


        //
        // GET: /Todo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }


        //
        // GET: /Todo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Todo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}