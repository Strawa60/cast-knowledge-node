using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.SearchEngine;
using CastKnowledgeWebApp.Tools;
using SyrinxMvc.Models;

namespace SyrinxMvc.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        private CastKnowledgeEntities db = new CastKnowledgeEntities();
        public int pageSize = 50;

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            CastKnowledgeWebApp.SearchEngine.Search searchResults = new Search(searchText);

            List<Dostawca_tagi> dTags = db.dostawca_tagi.ToList();
            List<string> selectedDTags = new List<string>();
            List<PairDataTemplate<int, List<string>>> contractorTags = new List<PairDataTemplate<int, List<string>>>();

            List<Odlewnia_tagi> fTags = db.odlewnia_tagi.ToList();
            List<string> selectedFTags = new List<string>();
            List<PairDataTemplate<int, List<string>>> foundryTags = new List<PairDataTemplate<int, List<string>>>();

            List<Patenty_tagi> ptTags = db.patenty_tagi.ToList();
            List<string> selectedPTTags = new List<string>();
            List<PairDataTemplate<int, List<string>>> patentTags = new List<PairDataTemplate<int, List<string>>>();

            List<Publikacje_tagi> pbTags = db.publikacje_tagi.ToList();
            List<string> selectedPBTags = new List<string>();
            List<PairDataTemplate<int, List<string>>> publicationTags = new List<PairDataTemplate<int, List<string>>>();

            try
            {

                for (int i = 0; i < searchResults.dostawcaResults.Count; i++)
                {
                    selectedDTags.Clear();
                    selectedDTags.AddRange(from t in dTags where searchResults.dostawcaResults[i].id_firmy == t.id_firmy select t.Slowa_kluczowe.nazwa);
                    contractorTags.Add(new PairDataTemplate<int, List<string>>(searchResults.dostawcaResults[i].id_firmy, new List<string>(selectedDTags)));
                }

                for (int i = 0; i < searchResults.odlewniaResults.Count; i++)
                {
                    selectedFTags.Clear();
                    selectedFTags.AddRange(from t in fTags where searchResults.odlewniaResults[i].id_odlewni == t.id_odlewni select t.Slowa_kluczowe.nazwa);
                    foundryTags.Add(new PairDataTemplate<int, List<string>>(searchResults.odlewniaResults[i].id_odlewni, new List<string>(selectedFTags)));
                }

                for (int i = 0; i < searchResults.publikacjaResults.Count; i++)
                {
                    selectedPBTags.Clear();
                    selectedPBTags.AddRange(from t in pbTags where searchResults.publikacjaResults[i].id_publikacji == t.id_publikacji select t.Slowa_kluczowe.nazwa);
                    publicationTags.Add(new PairDataTemplate<int, List<string>>(searchResults.publikacjaResults[i].id_publikacji, new List<string>(selectedPBTags)));
                }

                for (int i = 0; i < searchResults.patentResults.Count; i++)
                {
                    selectedPTTags.Clear();
                    selectedPTTags.AddRange(from t in ptTags where searchResults.patentResults[i].id_patentu == t.id_patentu select t.Slowa_kluczowe.nazwa);
                    patentTags.Add(new PairDataTemplate<int, List<string>>(searchResults.patentResults[i].id_patentu, new List<string>(selectedPTTags)));
                }

                SyrinxMvc.Models.SearchResults viewModel = new SearchResults
                {
                    contractors = searchResults.dostawcaResults,
                    keyWordsContractor = contractorTags,

                    foundries = searchResults.odlewniaResults,
                    keyWordsFoundry = foundryTags,

                    patents = searchResults.patentResults,
                    keyWordsPatent = patentTags,

                    publications = searchResults.publikacjaResults,
                    keyWordsPublication = publicationTags
                
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


    }
}
