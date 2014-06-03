using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using SyrinxMvc.Models;

namespace SyrinxMvc.Controllers
{
    public class PatentyController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 50;
        //
        // GET: /Patenty/

        public ActionResult Index(int page = 1)
        {
            List<Patenty> patentsList = new List<Patenty>();
            List<Patenty_tagi> tags = new List<Patenty_tagi>();
            List<PairDataTemplate<int, List<string>>> patentsTags = new List<PairDataTemplate<int, List<string>>>();
            List<string> words2 = new List<string>();
            patentsList.Clear();
            tags.Clear();
            patentsTags.Clear();

            try
            {
                patentsList = db.patenty.ToList();
                tags = db.patenty_tagi.ToList();

                for (int i = 0; i < patentsList.Count; i++)
                {
                    words2.Clear();
                    for (int j = 0; j < tags.Count; j++)
                    {
                        if (patentsList[i].id_patentu == tags[j].id_patentu)
                        {
                            words2.Add(tags[j].Slowa_kluczowe.nazwa);
                        }
                    }
                    patentsTags.Add(new PairDataTemplate<int, List<string>>(patentsList[i].id_patentu, new List<string>(words2)));
                }

                PatentyListWrapper viewModel = new PatentyListWrapper
                {
                    patents = patentsList.OrderBy(p => p.id_patentu).Skip((page - 1) * pageSize).Take(pageSize),
                    pagingInfo = new PagingInfo
                    {
                        currentPage = page,
                        itemsPerPage = pageSize,
                        totalItems = patentsList.Count()
                    },
                    keyWords = patentsTags
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
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