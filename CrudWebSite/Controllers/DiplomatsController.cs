using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudWebSite.Models;

namespace CrudWebSite.Controllers
{
    public class DiplomatsController : Controller
    {
        private CrudSiteDataEntities db = new CrudSiteDataEntities();

        // GET: Diplomats
        public ActionResult Index()
        {
            var diplomats = db.Diplomats.Include(d => d.Country1).Include(d => d.Language1);
            return View(diplomats.ToList());
        }

        // GET: Diplomats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diplomat diplomat = db.Diplomats.Find(id);
            if (diplomat == null)
            {
                return HttpNotFound();
            }
            return View(diplomat);
        }

        // GET: Diplomats/Create
        public ActionResult Create()
        {
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryCode");
            ViewBag.Language = new SelectList(db.Languages, "Id", "LangCode");
            return View();
        }

        // POST: Diplomats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Language,Country")] Diplomat diplomat)
        {
            if (ModelState.IsValid)
            {
                db.Diplomats.Add(diplomat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryCode", diplomat.Country);
            ViewBag.Language = new SelectList(db.Languages, "Id", "LangCode", diplomat.Language);
            return View(diplomat);
        }

        // GET: Diplomats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diplomat diplomat = db.Diplomats.Find(id);
            if (diplomat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryCode", diplomat.Country);
            ViewBag.Language = new SelectList(db.Languages, "Id", "LangCode", diplomat.Language);
            return View(diplomat);
        }

        // POST: Diplomats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Language,Country")] Diplomat diplomat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diplomat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country = new SelectList(db.Countries, "Id", "CountryCode", diplomat.Country);
            ViewBag.Language = new SelectList(db.Languages, "Id", "LangCode", diplomat.Language);
            return View(diplomat);
        }

        // GET: Diplomats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diplomat diplomat = db.Diplomats.Find(id);
            if (diplomat == null)
            {
                return HttpNotFound();
            }
            return View(diplomat);
        }

        // POST: Diplomats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diplomat diplomat = db.Diplomats.Find(id);
            db.Diplomats.Remove(diplomat);
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
