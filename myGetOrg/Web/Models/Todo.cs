using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOrganized.Web.Models
{
    public class Todo
    {
        public static List<Todo> ThingsToBeDone = new List<Todo>
         {
         new Todo {Title = "Get Milk" , Completed = false},
         new Todo {Title = "Bring Home Bacon" , Completed = false}
         };

        public bool Completed { get; set; }
        public string Title { get; set; }
    }
}