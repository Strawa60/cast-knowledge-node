using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.ExcelParserEngine;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using System.Collections;

namespace CastKnowledgeWebApp.Controllers
{
    public class ExcelDataInsertController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        

        //
        // GET: /ExcelDataInsert/

        public ActionResult Index()
        {
            List<PariDataTemplate<Dostawca, List<string>>> dataFromExcel = new List<PariDataTemplate<Dostawca, List<string>>>();
            dataFromExcel = CastKnowledgeWebApp.ExcelParserEngine.ExcelParser.ParseContractorData();

            Slowa_kluczowe keyWord = new Slowa_kluczowe();

            ArrayList keyWordsIdTables = new ArrayList();
            ArrayList contractorIdTables = new ArrayList();


            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                for (int j = 0; j < dataFromExcel[i].typeTwo.Count; j++)
                {
                    keyWord.nazwa = dataFromExcel[i].typeTwo[j];

                    db.slowa_kluczowe.Add(keyWord);
                    db.SaveChanges();
                    keyWordsIdTables.Add(keyWord.id_deskryptora);

                }
            }

            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                //try
                //{
                    db.dostawca.Add(dataFromExcel[i].typeOne);
                    db.SaveChanges();
                    contractorIdTables.Add(dataFromExcel[i].typeOne.id_firmy);
                //}
                //catch(Exception e)
                //{
                //    continue;
                //}
            }


            return View();
        }


    }
}
