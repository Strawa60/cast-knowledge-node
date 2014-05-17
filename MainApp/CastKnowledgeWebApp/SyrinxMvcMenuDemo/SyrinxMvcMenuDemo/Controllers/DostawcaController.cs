using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using SyrinxMvc.Models;

namespace SyrinxMvc.Controllers
{
    public class DostawcaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 4;
        //
        // GET: /Dostawca/

        public ActionResult Index(int page = 1)
        {
            try
            {
                List<Dostawca> contractorList = new List<Dostawca>();
                contractorList = db.dostawca.ToList();

                DostawcaWrapper viewModel = new DostawcaWrapper
                {
                    contractors = contractorList.OrderBy(p => p.id_firmy).Skip((page - 1) * pageSize).Take(pageSize),
                    pagingInfo = new PagingInfo
                    {
                        currentPage = page,
                        itemsPerPage = pageSize,
                        totalItems = contractorList.Count()
                    }
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                //return View("ConnectionErrorPartial");
                return View("Error");
            }
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

            var result = db.Set<Dostawca_tagi>().Where(x => x.id_firmy == id).ToList();

            foreach (var item in result)
            {
                db.dostawca_tagi.Remove(item);
                //db.SaveChanges();
            }

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