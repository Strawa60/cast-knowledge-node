using System.ComponentModel.DataAnnotations;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dostawca_tagi
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> id_firmy { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
    
        public virtual Dostawca Dostawca { get; set; }
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
    }
}
