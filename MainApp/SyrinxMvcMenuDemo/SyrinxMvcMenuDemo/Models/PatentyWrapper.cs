using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;

namespace SyrinxMvc.Models
{
    public class PatentyWrapper
    {
        public Patenty patents { get; set; }
        public string keyWords { get; set; }
    }
}