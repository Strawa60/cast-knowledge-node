
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patenty_tagi
    {
        public int id { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
        public Nullable<int> id_patentu { get; set; }
    
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
        public virtual Patenty Patenty { get; set; }
    }
}
