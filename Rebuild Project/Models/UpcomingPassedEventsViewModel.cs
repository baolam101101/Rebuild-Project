using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rebuild_Project.Models;

namespace Rebuild_Project.Models
{
    public class UpcomingPassedEventsViewModel
    {
        public IEnumerable<EventViewModel> UpcomingEvents { get; set; }

        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}