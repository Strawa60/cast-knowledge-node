using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;

namespace SyrinxMvc.Controllers
{
    public class OdlewniaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        //
        // GET: /Odlewnia/

        public ActionResult Index()
        {
            return View(db.odlewnia.ToList());
        }

        //
        // GET: /Odlewnia/Details/5

        public ActionResult Details(int id = 0)
        {
            Odlewnia odlewnia = db.odlewnia.Find(id);
            if (odlewnia == null)
            {
                return HttpNotFound();
            }
            return View(odlewnia);
        }

        //
        // GET: /Odlewnia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Odlewnia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Odlewnia odlewnia)
        {
            if (ModelState.IsValid)
            {
                db.odlewnia.Add(odlewnia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odlewnia);
        }

        //
        // GET: /Odlewnia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Odlewnia odlewnia = db.odlewnia.Find(id);
            if (odlewnia == null)
            {
                return HttpNotFound();
            }
            return View(odlewnia);
        }

        //
        // POST: /Odlewnia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Odlewnia odlewnia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odlewnia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odlewnia);
        }

        //
        // GET: /Odlewnia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Odlewnia odlewnia = db.odlewnia.Find(id);
            if (odlewnia == null)
            {
                return HttpNotFound();
            }
            return View(odlewnia);
        }

        //
        // POST: /Odlewnia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odlewnia odlewnia = db.odlewnia.Find(id);
            db.odlewnia.Remove(odlewnia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}