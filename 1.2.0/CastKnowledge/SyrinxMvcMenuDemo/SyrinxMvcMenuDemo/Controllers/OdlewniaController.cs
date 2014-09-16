using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Tools;
using SyrinxMvc.Models;
using System.Text;

namespace SyrinxMvc.Controllers
{
    public class OdlewniaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 50;

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
            Odlewnia foundry = db.odlewnia.Find(id);
            OdlewniaWrapper fw = new OdlewniaWrapper();
            List<Odlewnia_tagi> keywordsDetails = db.odlewnia_tagi.ToList();

            StringBuilder sb = new StringBuilder();

            fw.foundries = foundry;

            for (int i = 0; i < keywordsDetails.Count; i++)
            {
                if (foundry.id_odlewni == keywordsDetails[i].id_odlewni)
                {
                    sb.Append(keywordsDetails[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            fw.keyWords = sb.ToString();

            if (foundry == null)
            {
                return HttpNotFound();
            }
            return View(fw);
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
        public ActionResult Create(OdlewniaWrapper fw)
        {
            if (ModelState.IsValid)
            {
                DbSaveData.InsertDataToDB.InsertFoundryDataFromForm(fw);
                return RedirectToAction("Index");
            }

            return View(fw);
        }

        //
        // GET: /Odlewnia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Odlewnia foundry = db.odlewnia.Find(id);
            OdlewniaWrapper fw = new OdlewniaWrapper();
            List<Odlewnia_tagi> keywordsEdit = new List<Odlewnia_tagi>();

            StringBuilder sb = new StringBuilder();

            keywordsEdit = db.odlewnia_tagi.ToList();

            fw.foundries = foundry;

            for (int i = 0; i < keywordsEdit.Count; i++)
            {
                if (foundry.id_odlewni == keywordsEdit[i].id_odlewni)
                {
                    sb.Append(keywordsEdit[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            fw.keyWords = sb.ToString();

            if (foundry == null)
            {
                return HttpNotFound();
            }
            return View(fw);
        }

        //
        // POST: /Odlewnia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OdlewniaWrapper fw)
        {
            Odlewnia foundry = fw.foundries;

            List<Odlewnia_tagi> temp = new List<Odlewnia_tagi>();
            temp = db.odlewnia_tagi.ToList();
            List<Slowa_kluczowe> temp2 = new List<Slowa_kluczowe>();
            List<string> temp3 = Container.SeparateKeyWords(fw.keyWords);
            List<Slowa_kluczowe> doDodania = new List<Slowa_kluczowe>();
            List<Slowa_kluczowe> doUsuniecia = new List<Slowa_kluczowe>();

            /////////////////przygotowanie listy tagow do edycji
            for (int i = 0; i < temp.Count; i++)
            {
                if (foundry.id_odlewni == temp[i].id_odlewni)
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
                    db.Entry(foundry).State = EntityState.Modified;
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
                                db.odlewnia_tagi.Remove(temp[i]);
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
                            db.odlewnia_tagi.Add(new Odlewnia_tagi { id_odlewni = foundry.id_odlewni, id_deskryptora = id });
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
            return View(fw);
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
            var result = db.Set<Odlewnia_tagi>().Where(x => x.id_odlewni == id).ToList();

            foreach (var item in result)
            {
                db.slowa_kluczowe.Remove(item.Slowa_kluczowe);
                db.odlewnia_tagi.Remove(item);
            }

            Odlewnia foundry = db.odlewnia.Find(id);
            db.odlewnia.Remove(foundry);
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