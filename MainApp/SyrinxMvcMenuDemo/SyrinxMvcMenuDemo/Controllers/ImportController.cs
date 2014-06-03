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
        private static string viewName;
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


                        if (viewName=="Dostawca")
                        {
                            idFailed = DbSaveData.InsertDataToDB.InsertContractorDataFromExcel(fileLocation);
                        }
                        else if (viewName == "Odlewnie")
                        {
                            idFailed = DbSaveData.InsertDataToDB.InsertFoundryDataFromExcel(fileLocation);
                        }
                        else if (viewName == "Publikacje")
                        {
                            idFailed = DbSaveData.InsertDataToDB.InsertPublicationDataFromExcel(fileLocation);
                        }
                        else if (viewName == "Patenty")
                        {
                            idFailed = DbSaveData.InsertDataToDB.InsertPatentsDataFromExcel(fileLocation);
                        }
                        else
                        {
                            idFailed = "ErrorOpenFile";
                        }

                        System.IO.File.Delete(fileLocation);
                    }
                }

                if (idFailed == null)
                {
                    return View("Consume");
                }
                else if (idFailed != "ErrorOpenFile")
                {
                    return View("ConsumeFailed", null, idFailed);
                }
                else if (idFailed == "ErrorOpenFile")
                {
                    return View("ErrorOpenFile");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
