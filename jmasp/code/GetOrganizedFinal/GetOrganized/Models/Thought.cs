/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;

namespace GetOrganized.Models
{
    public class Thought
    {
        public virtual int Id { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual string Name { get; set; }
        public virtual string ImageAttachment { get; set; }
        public virtual bool IsASomeday { get; set; }

        public virtual bool Equals(Thought other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && Equals(other.Topic, Topic) && Equals(other.Name, Name) && Equals(other.ImageAttachment, ImageAttachment) && other.IsASomeday.Equals(IsASomeday);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Thought)) return false;
            return Equals((Thought) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id;
                result = (result*397) ^ (Topic != null ? Topic.GetHashCode() : 0);
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                result = (result*397) ^ (ImageAttachment != null ? ImageAttachment.GetHashCode() : 0);
                result = (result*397) ^ IsASomeday.GetHashCode();
                return result;
            }
        }
    }
}