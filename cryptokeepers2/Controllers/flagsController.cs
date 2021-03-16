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
    public class flagsController : Controller
    {
        private cryptokeepersdb1Entities1 db = new cryptokeepersdb1Entities1();

        // GET: flags
        public ActionResult Index()
        {
            return View(db.flags.ToList().OrderBy(m => m.flagname));
        }

        // GET: flags/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flag flag = db.flags.Find(id);
            if (flag == null)
            {
                return HttpNotFound();
            }
            return View(flag);
        }

        // GET: flags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: flags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,flagname")] flag flag)
        {
            if (ModelState.IsValid)
            {
                db.flags.Add(flag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flag);
        }

        // GET: flags/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flag flag = db.flags.Find(id);
            if (flag == null)
            {
                return HttpNotFound();
            }
            return View(flag);
        }

        // POST: flags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,flagname")] flag flag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flag);
        }

        // GET: flags/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            flag flag = db.flags.Find(id);
            if (flag == null)
            {
                return HttpNotFound();
            }
            return View(flag);
        }

        // POST: flags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            flag flag = db.flags.Find(id);
            db.flags.Remove(flag);
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
