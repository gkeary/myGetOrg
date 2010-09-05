/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
﻿using System.Collections.Generic;

namespace GetOrganized.Models
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

            //This Equals makes sure what's in the lists is compared, not the reference
            //equality on the List<T> itself
            if (other.AddedTodos.Count != other.AddedTodos.Count) return false;
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
            if (obj.GetType() != typeof (SessionSummary)) return false;
            return Equals((SessionSummary) obj);
        }

        public override int GetHashCode()
        {
            return (AddedTodos != null ? AddedTodos.GetHashCode() : 0);
        }
    }
}