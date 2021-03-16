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
    public class alertsController : Controller
    {
        private cryptokeepersdb1Entities1 db = new cryptokeepersdb1Entities1();

        // GET: alerts
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var alerts = db.alerts.Include(a => a.coin1).Include(a => a.entity1).Include(a => a.flag1).Include(a => a.priority1).Include(a => a.type1);
            if (!String.IsNullOrEmpty(searchString))
            {
                alerts = alerts.Where(s => s.concern.Contains(searchString));
            }
 
        
            return View(alerts.ToList().OrderByDescending(m=>m.id));
        }

        // GET: alerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alert alert = db.alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // GET: alerts/Create
        public ActionResult Create()
        {
            ViewBag.coin = new SelectList(db.coins, "id", "coinname");
            ViewBag.entity = new SelectList(db.entities, "id", "entityname");
            ViewBag.flag = new SelectList(db.flags, "id", "flagname");
            ViewBag.priority = new SelectList(db.priorities, "id", "priorityname");
            ViewBag.type = new SelectList(db.types, "id", "typename");
            return View();
        }

        // POST: alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,concern,flag,priority,entity,notes,reported,coin")] alert alert)
        {
            if (ModelState.IsValid)
            {
                db.alerts.Add(alert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            alert x = new alert();
            

            ViewBag.coin = new SelectList(db.coins, "id", "coinname", alert.coin);
            ViewBag.entity = new SelectList(db.entities, "id", "entityname", alert.entity);
            ViewBag.flag = new SelectList(db.flags, "id", "flagname", alert.flag);
            ViewBag.priority = new SelectList(db.priorities, "id", "priorityname", alert.priority);
            ViewBag.type = new SelectList(db.types, "id", "typename", alert.type);
            return View(alert);
        }

        // GET: alerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alert alert = db.alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            ViewBag.coin = new SelectList(db.coins, "id", "coinname", alert.coin);
            ViewBag.entity = new SelectList(db.entities, "id", "entityname", alert.entity);
            ViewBag.flag = new SelectList(db.flags, "id", "flagname", alert.flag);
            ViewBag.priority = new SelectList(db.priorities, "id", "priorityname", alert.priority);
            ViewBag.type = new SelectList(db.types, "id", "typename", alert.type);
            return View(alert);
        }

        // POST: alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,concern,flag,priority,entity,notes,reported,coin")] alert alert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coin = new SelectList(db.coins, "id", "coinname", alert.coin);
            ViewBag.entity = new SelectList(db.entities, "id", "entityname", alert.entity);
            ViewBag.flag = new SelectList(db.flags, "id", "flagname", alert.flag);
            ViewBag.priority = new SelectList(db.priorities, "id", "priorityname", alert.priority);
            ViewBag.type = new SelectList(db.types, "id", "typename", alert.type);
            return View(alert);
        }

        // GET: alerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alert alert = db.alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // POST: alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alert alert = db.alerts.Find(id);
            db.alerts.Remove(alert);
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
