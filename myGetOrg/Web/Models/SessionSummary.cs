using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOrganized.Web.Models
{
    public class SessionSummary
    {

        public List<Todo> AddedTodos { get; private set; }

        public SessionSummary()
        {
            AddedTodos = new List<Todo>();
        }

        public bool Equals(SessionSummary other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            //This Equals makes sure what's in the lists is 
            // compared, not the reference
// ReSharper disable EqualExpressionComparison
            if (other.AddedTodos.Count != other.AddedTodos.Count)
// ReSharper restore EqualExpressionComparison
                return false;

            for (int i = 0; i < other.AddedTodos.Count; i++)
            {
                if (!other.AddedTodos[i].Equals(AddedTodos[i]))
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(SessionSummary))
                return false;

            return Equals((SessionSummary)obj);
        }

        public override int GetHashCode()
        {
            return (AddedTodos != null ? AddedTodos.GetHashCode() : 0);


        }
    }
}