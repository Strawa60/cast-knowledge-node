using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;

namespace CastKnowledgeWebApp.Controllers
{
    public class DostawcaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        //
        // GET: /Dostawca/

        public ActionResult Index()
        {
            var dostawca = db.dostawca.Include(d => d.Typ_firmy);
            return View(dostawca.ToList());
        }

        //
        // GET: /Dostawca/Details/5

        public ActionResult Details(int id = 0)
        {
            Dostawca dostawca = db.dostawca.Find(id);
            if (dostawca == null)
            {
                return HttpNotFound();
            }
            return View(dostawca);
        }

        //
        // GET: /Dostawca/Create

        public ActionResult Create()
        {
            ViewBag.id_term = new SelectList(db.typ_firmy, "id_term", "nazwa");
            return View();
        }

        //
        // POST: /Dostawca/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dostawca dostawca)
        {

            if (ModelState.IsValid)
            {
                db.dostawca.Add(dostawca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_term = new SelectList(db.typ_firmy, "id_term", "nazwa", dostawca.id_term);
            return View(dostawca);
        }

        //
        // GET: /Dostawca/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dostawca dostawca = db.dostawca.Find(id);
            if (dostawca == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_term = new SelectList(db.typ_firmy, "id_term", "nazwa", dostawca.id_term);
            return View(dostawca);
        }

        //
        // POST: /Dostawca/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dostawca dostawca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dostawca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_term = new SelectList(db.typ_firmy, "id_term", "nazwa", dostawca.id_term);
            return View(dostawca);
        }

        //
        // GET: /Dostawca/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dostawca dostawca = db.dostawca.Find(id);
            if (dostawca == null)
            {
                return HttpNotFound();
            }
            return View(dostawca);
        }

        //
        // POST: /Dostawca/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dostawca dostawca = db.dostawca.Find(id);
            db.dostawca.Remove(dostawca);
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