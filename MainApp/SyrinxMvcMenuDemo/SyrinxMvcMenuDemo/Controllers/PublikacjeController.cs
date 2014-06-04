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
using System.Text;

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
            Publikacje publication = db.publikacje.Find(id);
            PublikacjeWrapper pw = new PublikacjeWrapper();
            List<Publikacje_tagi> keywordsDetails = db.publikacje_tagi.ToList();

            StringBuilder sb = new StringBuilder();

            pw.publications = publication;

            for (int i = 0; i < keywordsDetails.Count; i++)
            {
                if (publication.id_publikacji == keywordsDetails[i].id_publikacji)
                {
                    sb.Append(keywordsDetails[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            pw.keyWords = sb.ToString();

            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(pw);
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
        public ActionResult Create(PublikacjeWrapper publication)
        {
            if (ModelState.IsValid)
            {
                DbSaveData.InsertDataToDB.InsertPublicationDataFromForm(publication);
                return RedirectToAction("Index");
            }

            return View(publication);
        }

        //
        // GET: /Publikacje/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Publikacje publication = db.publikacje.Find(id);
            PublikacjeWrapper pw = new PublikacjeWrapper();
            List<Publikacje_tagi> keywordsEdit = new List<Publikacje_tagi>();

            StringBuilder sb = new StringBuilder();

            keywordsEdit = db.publikacje_tagi.ToList();

            pw.publications = publication;

            for (int i = 0; i < keywordsEdit.Count; i++)
            {
                if (publication.id_publikacji == keywordsEdit[i].id_publikacji)
                {
                    sb.Append(keywordsEdit[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            pw.keyWords = sb.ToString();

            if (publication == null)
            {
                return HttpNotFound();
            }
            return View(pw);
        }

        //
        // POST: /Publikacje/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublikacjeWrapper pw)
        {
            Publikacje publication = pw.publications;

            List<Publikacje_tagi> temp = new List<Publikacje_tagi>();
            temp = db.publikacje_tagi.ToList();
            List<Slowa_kluczowe> temp2 = new List<Slowa_kluczowe>();
            List<string> temp3 = Helpers.Contener.SeparateKeyWords(pw.keyWords);
            List<Slowa_kluczowe> doDodania = new List<Slowa_kluczowe>();
            List<Slowa_kluczowe> doUsuniecia = new List<Slowa_kluczowe>();

            /////////////////przygotowanie listy tagow do edycji
            for (int i = 0; i < temp.Count; i++)
            {
                if (publication.id_publikacji == temp[i].id_publikacji)
                {
                    temp2.Add(temp[i].Slowa_kluczowe);
                }
            }


            for (int i = 0; i < temp3.Count; i++)
            {
                for (int j = 0; j < temp2.Count; j++)
                {
                    if (temp3[i] != null && temp2[j] != null)
                    {
                        if (temp3[i] == temp2[j].nazwa)
                        {
                            temp3[i] = null;
                            temp2[j] = null;
                        }
                    }
                }
            }

            for (int i = 0; i < temp3.Count; i++)
            {
                if (temp3[i] != null)
                {
                    doDodania.Add(new Slowa_kluczowe { nazwa = temp3[i] });
                }
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                if (temp2[i] != null)
                {
                    doUsuniecia.Add(temp2[i]);
                }
            }

            //////////////////////////////////////////////////////////////
            Slowa_kluczowe tempolary = new Slowa_kluczowe();
            int id = 0;

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(publication).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return View("Error");
                }

                if (doUsuniecia.Count > 0)
                {
                    foreach (var q in doUsuniecia)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            if (temp[i].Slowa_kluczowe == q)
                            {
                                db.publikacje_tagi.Remove(temp[i]);
                            }
                        }
                        db.slowa_kluczowe.Remove(q);
                    }
                    db.SaveChanges();
                }
                if (doDodania.Count > 0)
                {
                    try
                    {
                        foreach (var q in doDodania)
                        {
                            db.slowa_kluczowe.Add(q);
                            id = q.id_deskryptora;
                            db.publikacje_tagi.Add(new Publikacje_tagi { id_publikacji = publication.id_publikacji, id_deskryptora = id });
                        }
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return View("Error");
                    }
                }

                return RedirectToAction("Index");
            }
            return View(pw);
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
            var result = db.Set<Publikacje_tagi>().Where(x => x.id_publikacji == id).ToList();

            foreach (var item in result)
            {
                db.slowa_kluczowe.Remove(item.Slowa_kluczowe);
                db.publikacje_tagi.Remove(item);
            }

            Publikacje publication = db.publikacje.Find(id);
            db.publikacje.Remove(publication);
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