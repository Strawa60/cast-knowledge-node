using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;

namespace CastKnowledgeWebApp.Models
{
    public class DostawcaWrapper
    {
        public IEnumerable<Dostawca> contractors { get; set; }
        public PagingInfo pagingInfo { get; set; }

    }
}