using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;

namespace SyrinxMvc.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        [HttpPost]
        public ActionResult Seacrh()
        {



            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
