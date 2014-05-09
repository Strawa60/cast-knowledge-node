using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patenty_tagi
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> numer_wynalazku { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
    
        public virtual Patenty Patenty { get; set; }
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
    }
}
