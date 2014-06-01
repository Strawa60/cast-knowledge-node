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
    public class OdlewniaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 10;

        //
        // GET: /Odlewnia/

        public ActionResult Index(int page = 1)
        {
            List<Odlewnia> foundryList = new List<Odlewnia>();
            List<Odlewnia_tagi> tags = new List<Odlewnia_tagi>();
            List<PairDataTemplate<int, List<string>>> foundryTags = new List<PairDataTemplate<int, List<string>>>();
            List<string> words2 = new List<string>();
            foundryList.Clear();
            tags.Clear();
            foundryTags.Clear();

            try
            {
                foundryList = db.odlewnia.ToList();
                tags = db.odlewnia_tagi.ToList();

                for (int i = 0; i < foundryList.Count; i++)
                {
                    words2.Clear();
                    for (int j = 0; j < tags.Count; j++)
                    {
                        if (foundryList[i].id_odlewni == tags[j].id_odlewni)
                        {
                            words2.Add(tags[j].Slowa_kluczowe.nazwa);
                        }
                    }
                    foundryTags.Add(new PairDataTemplate<int, List<string>>(foundryList[i].id_odlewni, new List<string>(words2)));
                }

                OdlewniaListWrapper viewModel = new OdlewniaListWrapper
                {
                    foundries = foundryList.OrderBy(p => p.id_odlewni).Skip((page - 1) * pageSize).Take(pageSize),
                    pagingInfo = new PagingInfo
                    {
                        currentPage = page,
                        itemsPerPage = pageSize,
                        totalItems = foundryList.Count()
                    },
                    keyWords = foundryTags
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
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