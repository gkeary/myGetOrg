/***
 * Excerpted from "Test Drive ASP.NET MVC",
 * published by The Pragmatic Bookshelf.
 * Copyrights apply to this code. It may not be used to create training material, 
 * courses, books, articles, and the like. Contact us if you are in doubt.
 * We make no guarantees that this code is fit for any purpose. 
 * Visit http://www.pragmaticprogrammer.com/titles/jmasp for more book information.
***/
using FluentNHibernate.Mapping;
using GetOrganized.Models;

namespace GetOrganized.Persistence.ClassMaps
{
    public sealed class ThoughtMap : ClassMap<Thought>
    {
        public ThoughtMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.ImageAttachment);
            Map(x => x.IsASomeday);
            References(x => x.Topic);
        }
    }
}