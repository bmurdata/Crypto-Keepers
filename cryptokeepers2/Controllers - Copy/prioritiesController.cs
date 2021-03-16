using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cryptokeepers2.Models;

namespace cryptokeepers2.Controllers
{
    public class prioritiesController : Controller
    {
        private cryptokeepersdb1Entities db = new cryptokeepersdb1Entities();

        // GET: priorities
        public ActionResult Index()
        {
            return View(db.priorities.ToList());
        }

        // GET: priorities/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            priority priority = db.priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // GET: priorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: priorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,priorityname")] priority priority)
        {
            if (ModelState.IsValid)
            {
                db.priorities.Add(priority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priority);
        }

        // GET: priorities/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            priority priority = db.priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // POST: priorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,priorityname")] priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priority);
        }

        // GET: priorities/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            priority priority = db.priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        // POST: priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            priority priority = db.priorities.Find(id);
            db.priorities.Remove(priority);
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
