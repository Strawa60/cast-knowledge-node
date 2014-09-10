
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patenty_publikacja
    {
        public int id { get; set; }
        public Nullable<int> id_publikacji { get; set; }
        public Nullable<int> id_patentu { get; set; }
    
        public virtual Publikacje Publikacje { get; set; }
        public virtual Patenty patenty { get; set; }
    }
}
