using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rebuild_Project.Models;

namespace Rebuild_Project.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
    }
}