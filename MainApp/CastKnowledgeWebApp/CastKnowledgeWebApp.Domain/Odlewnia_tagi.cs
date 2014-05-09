using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odlewnia_tagi
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> id_odlewni { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
    
        public virtual Odlewnia Odlewnia { get; set; }
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
    }
}
