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
    public class EventsController : Controller
    {
        public int myid = 0;

        private DBContext db = new DBContext();

        public EventsController()
        {

            List<EventUser> eventuser = new List<EventUser>();
        }
        // GET: Events
        public ActionResult Index()
        {
            
            return View(db.Events.ToList());

        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
           
            Session["myid"] = id;
            
            var data = (from users in db.EventUser                        
                       where users.EventId == id
                       select users.UserName).ToArray();

            ViewBag.usersList = data;
            
            // List<EventUser> data = db.EventUser.ToList();
            //     data.Where(e => e.EventId == id);
            //  List<EventUser> data = new List<EventUser>() { db.EventUser.Find(id) };
            //   var results = db.EventUser.Find(id);

            //from b in db.Users
            //from a in db.Events
            //select new
            //{
            //    b.UserId,
            //    b.UserName,                              
            //    myResult = (from ab in db.EventUser
            //                where (ab.UserId == id) && (ab.EventId == id)
            //                select ab)
            //};
            // ViewBag.Result = results;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,EventName,EventLocation,EventOrganizer,EventDate")] Events events)
        {
            if (ModelState.IsValid)
            {

                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,EventLocation,EventOrganizer,EventDate")] Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.Events.Find(id);
            db.Events.Remove(events);
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
