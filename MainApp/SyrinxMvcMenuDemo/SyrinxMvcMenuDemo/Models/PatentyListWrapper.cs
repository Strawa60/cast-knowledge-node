﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Libraries.MultiTableDependency;

namespace SyrinxMvc.Models
{
    public class PatentyListWrapper
    {
        public IEnumerable<Patenty> patents { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public List<PairDataTemplate<int, List<string>>> keyWords { get; set; }
    }
}