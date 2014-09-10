using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Libraries.MultiTableDependency;
using SyrinxMvc.Models;
using System.Text;

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
            Patenty patent = db.patenty.Find(id);
            PatentyWrapper ptn = new PatentyWrapper();
            List<Patenty_tagi> keywordsDetails = db.patenty_tagi.ToList();

            StringBuilder sb = new StringBuilder();

            ptn.patents = patent;

            for (int i = 0; i < keywordsDetails.Count; i++)
            {
                if (patent.id_patentu == keywordsDetails[i].id_patentu)
                {
                    sb.Append(keywordsDetails[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            ptn.keyWords = sb.ToString();

            if (patent == null)
            {
                return HttpNotFound();
            }
            return View(ptn);
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
        public ActionResult Create(PatentyWrapper ptn)
        {
            if (ModelState.IsValid)
            {
                DbSaveData.InsertDataToDB.InsertPatentDataFromForm(ptn);
                return RedirectToAction("Index");
            }

            return View(ptn);
        }

        //
        // GET: /Patenty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patenty patent = db.patenty.Find(id);
            PatentyWrapper ptn = new PatentyWrapper();
            List<Patenty_tagi> keywordsEdit = new List<Patenty_tagi>();

            StringBuilder sb = new StringBuilder();

            keywordsEdit = db.patenty_tagi.ToList();

            ptn.patents = patent;

            for (int i = 0; i < keywordsEdit.Count; i++)
            {
                if (patent.id_patentu == keywordsEdit[i].id_patentu)
                {
                    sb.Append(keywordsEdit[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            ptn.keyWords = sb.ToString();

            if (patent == null)
            {
                return HttpNotFound();
            }
            return View(ptn);
        }

        //
        // POST: /Patenty/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatentyWrapper ptn)
        {
            Patenty patent = ptn.patents;

            List<Patenty_tagi> temp = new List<Patenty_tagi>();
            temp = db.patenty_tagi.ToList();
            List<Slowa_kluczowe> temp2 = new List<Slowa_kluczowe>();
            List<string> temp3 = Helpers.Contener.SeparateKeyWords(ptn.keyWords);
            List<Slowa_kluczowe> doDodania = new List<Slowa_kluczowe>();
            List<Slowa_kluczowe> doUsuniecia = new List<Slowa_kluczowe>();

            /////////////////przygotowanie listy tagow do edycji
            for (int i = 0; i < temp.Count; i++)
            {
                if (patent.id_patentu == temp[i].id_patentu)
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
                    db.Entry(patent).State = EntityState.Modified;
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
                                db.patenty_tagi.Remove(temp[i]);
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
                            db.patenty_tagi.Add(new Patenty_tagi { id_patentu = patent.id_patentu, id_deskryptora = id });
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
            return View(ptn);
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
            var result = db.Set<Patenty_tagi>().Where(x => x.id_patentu == id).ToList();

            foreach (var item in result)
            {
                db.slowa_kluczowe.Remove(item.Slowa_kluczowe);
                db.patenty_tagi.Remove(item);
            }

            Patenty patent = db.patenty.Find(id);
            db.patenty.Remove(patent);
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