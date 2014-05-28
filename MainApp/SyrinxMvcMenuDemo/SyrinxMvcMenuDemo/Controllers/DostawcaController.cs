using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using SyrinxMvc.Models;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using System.Text;

namespace SyrinxMvc.Controllers
{
    public class DostawcaController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 10;
        //
        // GET: /Dostawca/

        public ActionResult Index(int page = 1)
        {
            List<Dostawca> contractorList = new List<Dostawca>();
            List<Dostawca_tagi> tags = new List<Dostawca_tagi>();
            List<PairDataTemplate<int, List<string>>> contractorTags = new List<PairDataTemplate<int, List<string>>>();
            List<string> words2 = new List<string>();
            contractorList.Clear();
            tags.Clear();
            contractorTags.Clear();

            try
            {
                
                contractorList = db.dostawca.ToList();
                tags = db.dostawca_tagi.ToList();
                
                for (int i = 0; i < contractorList.Count; i++)
                {
                    words2.Clear();
                    for (int j = 0; j < tags.Count; j++)
                    {
                        if (contractorList[i].id_firmy == tags[j].id_firmy)
                        {
                            words2.Add(tags[j].Slowa_kluczowe.nazwa);
                        }
                    }
                    contractorTags.Add(new PairDataTemplate<int, List<string>>(contractorList[i].id_firmy, new List<string>(words2)));
                }                

                DostawcaListWrapper viewModel = new DostawcaListWrapper
                {
                    contractors = contractorList.OrderBy(p => p.id_firmy).Skip((page - 1) * pageSize).Take(pageSize),
                    pagingInfo = new PagingInfo
                    {
                        currentPage = page,
                        itemsPerPage = pageSize,
                        totalItems = contractorList.Count()
                    },
                    keyWords=contractorTags
                };

                return View(viewModel);
            }
            catch (Exception)
            {
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
        [ValidateAntiForgeryToken]//property= dostawca create wrapper
        public ActionResult Create(DostawcaCreateWrapper dcw)
        {
            if (ModelState.IsValid)
            {
                DbSaveData.InsertDataToDB.InsertContractorDataFromForm(dcw);
                return RedirectToAction("Index");
            }

            return View(dcw);
        }

        //
        // GET: /Dostawca/Edit/5
        

        public ActionResult Edit(int id = 0)
        {
            Dostawca dostawca = db.dostawca.Find(id);
            DostawcaCreateWrapper dcw = new DostawcaCreateWrapper();
            //List<Dostawca_tagi> 
            List<Dostawca_tagi> keywordsEdit = new List<Dostawca_tagi>();

            StringBuilder sb = new StringBuilder();

            keywordsEdit = db.dostawca_tagi.ToList();

            dcw.contractors = dostawca;

            for (int i = 0; i < keywordsEdit.Count;i++ )
            {
                if (dostawca.id_firmy == keywordsEdit[i].id_firmy)
                {
                    sb.Append(keywordsEdit[i].Slowa_kluczowe.nazwa).Append("; ");
                }
            }

            dcw.keyWords = sb.ToString();

            if (dostawca == null)
            {
                return HttpNotFound();
            }


            return View(dcw);



        }

        //
        // POST: /Dostawca/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DostawcaCreateWrapper dcw)
        {
            Dostawca dostawca = dcw.contractors;
            int param;

            List<Dostawca_tagi> temp = new List<Dostawca_tagi>();
            temp = db.dostawca_tagi.ToList();
            List<Slowa_kluczowe> temp2 = new List<Slowa_kluczowe>();
            List<string> temp3 = Helpers.Contener.SeparateKeyWords(dcw.keyWords);
            List<Slowa_kluczowe> doDodania = new List<Slowa_kluczowe>();
            List<Slowa_kluczowe> doUsuniecia = new List<Slowa_kluczowe>();

/////////////////przygotowanie listy tagow do edycji
            for (int i = 0; i < temp.Count; i++)
            {
                if (dostawca.id_firmy == temp[i].id_firmy)
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
                db.Entry(dostawca).State = EntityState.Modified;
                db.SaveChanges();

                if (doUsuniecia.Count > 0)
                {
                    foreach (var q in doUsuniecia)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            if (temp[i].Slowa_kluczowe == q)
                            {
                                db.dostawca_tagi.Remove(temp[i]);
                            }
                        }
                        db.slowa_kluczowe.Remove(q);
                    }
                    db.SaveChanges();
                }                
                if (doDodania.Count > 0)
                {
                    foreach (var q in doDodania)
                    {
                        db.slowa_kluczowe.Add(q);
                        id = q.id_deskryptora;
                        db.dostawca_tagi.Add(new Dostawca_tagi { id_firmy = dostawca.id_firmy, id_deskryptora = id });
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(dcw);
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