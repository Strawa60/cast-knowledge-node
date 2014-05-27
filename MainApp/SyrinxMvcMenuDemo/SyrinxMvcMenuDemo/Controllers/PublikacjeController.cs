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
    public class PublikacjeController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        //
        // GET: /Publikacje/

        public ActionResult Index()
        {
            return View(db.publikacje.ToList());
        }

        //
        // GET: /Publikacje/Details/5

        public ActionResult Details(int id = 0)
        {
            Publikacje publikacje = db.publikacje.Find(id);
            if (publikacje == null)
            {
                return HttpNotFound();
            }
            return View(publikacje);
        }

        //
        // GET: /Publikacje/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publikacje/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publikacje publikacje)
        {
            if (ModelState.IsValid)
            {
                db.publikacje.Add(publikacje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publikacje);
        }

        //
        // GET: /Publikacje/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Publikacje publikacje = db.publikacje.Find(id);
            if (publikacje == null)
            {
                return HttpNotFound();
            }
            return View(publikacje);
        }

        //
        // POST: /Publikacje/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Publikacje publikacje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publikacje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publikacje);
        }

        //
        // GET: /Publikacje/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Publikacje publikacje = db.publikacje.Find(id);
            if (publikacje == null)
            {
                return HttpNotFound();
            }
            return View(publikacje);
        }

        //
        // POST: /Publikacje/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publikacje publikacje = db.publikacje.Find(id);
            db.publikacje.Remove(publikacje);
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