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
    public class txesController : Controller
    {
        private cryptokeepersdb1Entities1 db = new cryptokeepersdb1Entities1();

        // GET: txes
        public ActionResult Index()
        {
            return View(db.txes.ToList());
        }

        // GET: txes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tx tx = db.txes.Find(id);
            if (tx == null)
            {
                return HttpNotFound();
            }
            return View(tx);
        }

        // GET: txes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: txes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wallet,txid,date,incoming,value,coin")] tx tx)
        {
            if (ModelState.IsValid)
            {
                db.txes.Add(tx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tx);
        }

        // GET: txes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tx tx = db.txes.Find(id);
            if (tx == null)
            {
                return HttpNotFound();
            }
            return View(tx);
        }

        // POST: txes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wallet,txid,date,incoming,value,coin")] tx tx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tx);
        }

        // GET: txes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tx tx = db.txes.Find(id);
            if (tx == null)
            {
                return HttpNotFound();
            }
            return View(tx);
        }

        // POST: txes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tx tx = db.txes.Find(id);
            db.txes.Remove(tx);
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
