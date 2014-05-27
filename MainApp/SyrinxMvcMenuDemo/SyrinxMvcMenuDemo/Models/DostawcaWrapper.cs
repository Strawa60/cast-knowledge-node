using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;

namespace SyrinxMvc.Models
{
    public class DostawcaWrapper
    {
        public IEnumerable<Dostawca> contractors { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public List<PairDataTemplate<int, List<string>>>  keyWords { get; set; }
    }
}