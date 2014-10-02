using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Ontology;

namespace SyrinxMvc.Controllers
{
    public class OntologiaController : Controller
    {
        OwlCollection getOntologyCollection = new OwlCollection();

        //
        // GET: /Ontologia/

        public ActionResult Index()
        {
            getOntologyCollection = getOntologyCollection.CreateOwlCollection();

            return View(getOntologyCollection.OwlClassCollection[0]);
        }

    }
}
