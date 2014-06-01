using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using CastKnowledgeWebApp.Domain;
using System.Collections;

namespace SyrinxMvc.Controllers
{
    public class ImportController : Controller
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        private string viewName;
        //
        // GET: /Import/

        public ActionResult Import(string _viewName)
        {
            viewName = _viewName;
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase file)
        {
            string idFailed=null;
            try
            {
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);

                        idFailed=DbSaveData.InsertDataToDB.InsertContractorDataFromExcel(fileLocation);
                        System.IO.File.Delete(fileLocation);
                    }
                }
                if (idFailed == null)
                {
                    return View("Consume");
                }
                else
                {
                    return View("ConsumeFailed",null, idFailed);
                }
            }
            catch (Exception)
            {
                return View("ConsumeFailed",idFailed);
            }
        }

    }
}
