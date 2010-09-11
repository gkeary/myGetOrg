using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOrganized.Web.Models
{
    public class Thought
    {
        public static List<Thought> Thoughts = new List<Thought>
        {
            new Thought{
                Id = 1,
                Name = "Learn c# 3.5" ,
                Topic = Topic.Topics.Find(topic => topic.Name == "Work" )},
                new Thought{
                Id = 2,
                Name = "Build a Killer Web Application" ,
                Topic = Topic.Topics.Find(topic => topic.Name == "Home" )}
        };
        
        public int Id { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }
    }
}