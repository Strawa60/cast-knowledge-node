using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Tools;

namespace SyrinxMvc.Models
{
    public class SearchResults
    {
        //public PagingInfo pagingInfo { get; set; }


        public IEnumerable<Dostawca> contractors { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWordsContractor { get; set; }

        public IEnumerable<Odlewnia> foundries { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWordsFoundry { get; set; }

        public IEnumerable<Patenty> patents { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWordsPatent { get; set; }

        public IEnumerable<Publikacje> publications { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWordsPublication { get; set; }

    }
}