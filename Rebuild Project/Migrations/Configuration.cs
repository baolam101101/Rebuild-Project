namespace Rebuild_Project.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Rebuild_Project.Models;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Rebuild_Project.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUser(context, "admin@gmail.com", "1", "Admin");

                CreateRole(context, "Admin");
                AddUserToRole(context, "admin@gmail.com", "Admin");
                CreateSeveralEvents(context);
            }
        }

        private void CreateSeveralEvents(ApplicationDbContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Party @ SoftUni",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30),
                Author = context.Users.First(),
            }) ;

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Anonymous>",
                StartDateTime = DateTime.Now.AddDays(-2).AddHours(10).AddMinutes(30),
                Duration = TimeSpan.FromHours(1.5),
                Commments = new HashSet<Comment>()
                {
                    new Comment() { Text = "<Anonymous> comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First() }
                }
            });
                
            context.Events.Add(new Event()
            {
                Title = "Upcoming Events",
                StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30),
                Duration = TimeSpan.FromHours(1.5),
                Author = context.Users.First(),
            });
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullname)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullname
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole (ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
