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
    public class coinsController : Controller
    {
        private cryptokeepersdb1Entities1 db = new cryptokeepersdb1Entities1();

        // GET: coins
        public ActionResult Index()
        {
            return View(db.coins.ToList().OrderBy(m=>m.coinname));
        }

        // GET: coins/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coin coin = db.coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // GET: coins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coinname")] coin coin)
        {
            if (ModelState.IsValid)
            {
                db.coins.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coin);
        }

        // GET: coins/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coin coin = db.coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // POST: coins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coinname")] coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coin);
        }

        // GET: coins/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coin coin = db.coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // POST: coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            coin coin = db.coins.Find(id);
            db.coins.Remove(coin);
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
