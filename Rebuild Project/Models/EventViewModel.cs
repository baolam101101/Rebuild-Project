using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rebuild_Project.Models;

namespace Rebuild_Project.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
    }
}