using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Tools;
using CastKnowledgeWebApp.Domain;


namespace SyrinxMvc.Models
{
    public class PublikacjeListWrapper
    {
        public IEnumerable<Publikacje> publications { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWords { get; set; }

    }
}