using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.ExcelParserEngine;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using System.Collections;
using System.Data;

namespace CastKnowledgeWebApp.Controllers
{
    public class ExcelDataInsertController : Controller
    {
        //
        // GET: /ExcelDataInsert/

        public ActionResult Index()
        {
            InsertDataToDB.InsertContractorDataFromExcel();


            return View("DONE");
        }


    }
}
