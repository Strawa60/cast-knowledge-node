
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publikacja_autor
    {
        public int id { get; set; }
        public Nullable<int> id_publikacji { get; set; }
        public Nullable<int> id_autora { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        public virtual Publikacje Publikacje { get; set; }
    }
}
