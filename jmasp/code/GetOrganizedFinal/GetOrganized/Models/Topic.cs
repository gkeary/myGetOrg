/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using System.Collections.Generic;
using System.Drawing;

namespace GetOrganized.Models
{
    public class Topic
    {
        public static readonly Topic NONE = new Topic {Id = 1, Color = Color.White, Name = "None"};

        public virtual int Id { get; set; }
        public virtual Color Color { get; set; }
        public virtual string Name { get; set; }

        public virtual string ColorHtml
        {
            get { return ColorTranslator.ToHtml(Color); }
            set { Color = ColorTranslator.FromHtml(value); }
        }

        public virtual bool Equals(Topic other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id && other.Color.Equals(Color) && Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Topic)) return false;
            return Equals((Topic) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id;
                result = (result*397) ^ Color.GetHashCode();
                result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
                return result;
            }
        }
    }
}