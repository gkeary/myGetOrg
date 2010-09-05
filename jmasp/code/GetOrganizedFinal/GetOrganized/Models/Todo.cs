/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System;
using GetOrganized.Models.Validator;
using NHibernate.Validator.Constraints;

namespace GetOrganized.Models
{
    public class Todo : IValidatable
    {
        public virtual bool Completed { get; set; }

        [Length(0, 25)]
        public virtual string Title { get; set; }

        public virtual string Outcome { get; set; }
        public virtual Topic Topic { get; set; }

        public virtual int Id { get; set; }

        public virtual bool Equals(Todo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Completed.Equals(Completed) && Equals(other.Title, Title) && Equals(other.Outcome, Outcome) && Equals(other.Topic, Topic) && other.Id == Id;
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
                result = (result*397) ^ Id;
                return result;
            }
        }
    }
}