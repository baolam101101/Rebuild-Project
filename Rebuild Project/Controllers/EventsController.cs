using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Rebuild_Project.Models;

namespace Rebuild_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : BaseController
    {
        // GET: Events
        public ActionResult My()
        {
            return View(db.EventInputModels.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInputModel eventInputModel = db.EventInputModels.Find(id);
            if (eventInputModel == null)
            {
                return HttpNotFound();
            }
            return View(eventInputModel);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };

                this.db.Events.Add(e);
                this.db.SaveChanges();

                return RedirectToAction("My");
            }

            return this.View(model);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInputModel eventInputModel = db.EventInputModels.Find(id);
            if (eventInputModel == null)
            {
                return HttpNotFound();
            }
            return View(eventInputModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDateTime,Duration,Description,Location,IsPublic")] EventInputModel eventInputModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventInputModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("My");
            }
            return View(eventInputModel);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventInputModel eventInputModel = db.EventInputModels.Find(id);
            if (eventInputModel == null)
            {
                return HttpNotFound();
            }
            return View(eventInputModel);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInputModel eventInputModel = db.EventInputModels.Find(id);
            db.EventInputModels.Remove(eventInputModel);
            db.SaveChanges();
            return RedirectToAction("My");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
