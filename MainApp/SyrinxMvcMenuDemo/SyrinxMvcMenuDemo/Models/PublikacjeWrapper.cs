using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;

namespace SyrinxMvc.Models
{
    public class PublikacjeWrapper
    {
        public Publikacje publications { get; set; }
        public string keyWords { get; set; }
    }
}