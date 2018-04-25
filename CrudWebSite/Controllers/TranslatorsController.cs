﻿using System;
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
    public class TranslatorsController : Controller
    {
        private CrudSiteDataEntities db = new CrudSiteDataEntities();

        // GET: Translators
        public ActionResult Index()
        {
            return View(db.Translators.ToList());
        }

        // GET: Translators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translator translator = db.Translators.Find(id);
            if (translator == null)
            {
                return HttpNotFound();
            }
            return View(translator);
        }

        // GET: Translators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Translators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fullname,Photo,Ensign,DOB")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                db.Translators.Add(translator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(translator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVm([Bind(Include = "Id,Fullname,Photo,Ensign,DOB")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                db.Translators.Add(translator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(translator);
        }

        public ActionResult CreateVm()
        {
            return View();
        }

        // GET: Translators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translator translator = db.Translators.Find(id);
            if (translator == null)
            {
                return HttpNotFound();
            }
            return View(translator);
        }

        // POST: Translators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fullname,Photo,Ensign,DOB")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(translator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(translator);
        }

        // GET: Translators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translator translator = db.Translators.Find(id);
            if (translator == null)
            {
                return HttpNotFound();
            }
            return View(translator);
        }

        // POST: Translators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Translator translator = db.Translators.Find(id);
            db.Translators.Remove(translator);
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
