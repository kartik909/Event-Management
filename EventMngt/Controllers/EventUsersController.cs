using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventMngt.Models;

namespace EventMngt.Controllers
{
    public class EventUsersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: EventUsers
        public ActionResult Index()
        {
            var eventUser = db.EventUser.Include(e => e.Events).Include(e => e.Users);

            return View(eventUser.ToList());
        }

        // GET: EventUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventUser.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            return View(eventUser);
        }

        // GET: EventUsers/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: EventUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventUserId,EventId,UserId")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                db.EventUser.Add(eventUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", eventUser.UserId);
            return View(eventUser);
        }

        // GET: EventUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventUser.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", eventUser.UserId);
            return View(eventUser);
        }

        // POST: EventUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventUserId,EventId,UserId")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", eventUser.UserId);
            return View(eventUser);
        }

        // GET: EventUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventUser.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            return View(eventUser);
        }

        // POST: EventUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventUser eventUser = db.EventUser.Find(id);
            db.EventUser.Remove(eventUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
