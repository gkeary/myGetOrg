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
        public string Outcome { get; set; }
        public Topic Topic  { get; set; }

        public bool Equals(Todo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Completed.Equals(Completed) && Equals(other.Title, Title) && Equals(other.Outcome, Outcome) && Equals(other.Topic, Topic);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Todo)) return false;
            return Equals((Todo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Completed.GetHashCode();
                result = (result*397) ^ (Title != null ? Title.GetHashCode() : 0);
                result = (result*397) ^ (Outcome != null ? Outcome.GetHashCode() : 0);
                result = (result*397) ^ (Topic != null ? Topic.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(Todo left, Todo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Todo left, Todo right)
        {
            return !Equals(left, right);
        }
    }
}