
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patent_autor
    {
        public int id { get; set; }
        public Nullable<int> id_autora { get; set; }
        public Nullable<int> id_patentu { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        public virtual Patenty Patenty { get; set; }
    }
}
