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
    public class PatentyController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        //
        // GET: /Patenty/

        public ActionResult Index()
        {
            return View(db.patenty.ToList());
        }

        //
        // GET: /Patenty/Details/5

        public ActionResult Details(int id = 0)
        {
            Patenty patenty = db.patenty.Find(id);
            if (patenty == null)
            {
                return HttpNotFound();
            }
            return View(patenty);
        }

        //
        // GET: /Patenty/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Patenty/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patenty patenty)
        {
            if (ModelState.IsValid)
            {
                db.patenty.Add(patenty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patenty);
        }

        //
        // GET: /Patenty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patenty patenty = db.patenty.Find(id);
            if (patenty == null)
            {
                return HttpNotFound();
            }
            return View(patenty);
        }

        //
        // POST: /Patenty/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patenty patenty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patenty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patenty);
        }

        //
        // GET: /Patenty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Patenty patenty = db.patenty.Find(id);
            if (patenty == null)
            {
                return HttpNotFound();
            }
            return View(patenty);
        }

        //
        // POST: /Patenty/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patenty patenty = db.patenty.Find(id);
            db.patenty.Remove(patenty);
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