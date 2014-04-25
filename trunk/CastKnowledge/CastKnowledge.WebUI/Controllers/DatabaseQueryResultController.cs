using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledge.Domain.Abstract;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.WebUI.Infrastructure.ExcelEngine;

namespace CastKnowledge.WebUI.Controllers
{
    public class DatabaseQueryResultController : Controller
    {

        private IDatabaseQueryResult result;

        public DatabaseQueryResultController(IDatabaseQueryResult Results)
        {
            this.result = Results;
        }

        public ViewResult List()
        {
            //abstract
            List<Contractor> dsadasd = new List<Contractor>();
            dsadasd = ExcelParserEngine.ParseContractorData();
           
            return View(result.DatabaseQueryResults);
        }


    }
}
