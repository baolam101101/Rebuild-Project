﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rebuild_Project.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Rebuild_Project.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<Rebuild_Project.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Rebuild_Project.Models.EventInputModel> EventInputModels { get; set; }
    }
}