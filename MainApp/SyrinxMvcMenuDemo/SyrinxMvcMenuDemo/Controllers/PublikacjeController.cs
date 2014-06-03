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
    public class PublikacjeController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 50;
        //
        // GET: /Publikacje/

        public ActionResult Index(int page = 1)
        {
            List<Publikacje> publicationsList = new List<Publikacje>();
            List<Publikacje_tagi> tags = new List<Publikacje_tagi>();
            List<PairDataTemplate<int, List<string>>> publicationsTags = new List<PairDataTemplate<int, List<string>>>();
            List<string> words2 = new List<string>();
            publicationsList.Clear();
            tags.Clear();
            publicationsTags.Clear();

            try
            {
                publicationsList = db.publikacje.ToList();
                tags = db.publikacje_tagi.ToList();

                for (int i = 0; i < publicationsList.Count; i++)
                {
                    words2.Clear();
                    for (int j = 0; j < tags.Count; j++)
                    {
                        if (publicationsList[i].id_publikacji == tags[j].id_publikacji)
                        {
                            words2.Add(tags[j].Slowa_kluczowe.nazwa);
                        }
                    }
                    publicationsTags.Add(new PairDataTemplate<int, List<string>>(publicationsList[i].id_publikacji, new List<string>(words2)));
                }

                PublikacjeListWrapper viewModel = new PublikacjeListWrapper
                {
                    publications = publicationsList.OrderBy(p => p.id_publikacji).Skip((page - 1) * pageSize).Take(pageSize),
                    pagingInfo = new PagingInfo
                    {
                        currentPage = page,
                        itemsPerPage = pageSize,
                        totalItems = publicationsList.Count()
                    },
                    keyWords = publicationsTags
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
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