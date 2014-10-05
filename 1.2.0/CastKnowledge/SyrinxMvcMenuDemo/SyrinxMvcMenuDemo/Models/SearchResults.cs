using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;

namespace SyrinxMvc.Models
{
    public class SearchResults
    {
        public List<Dostawca> dostawcaResultList { get; set; }
        public List<Odlewnia> odlewniaResultList { get; set; }
        public List<Patenty> patentResultList { get; set; }
        public List<Publikacje> publikacjaResultList { get; set; }


    }
}