using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patenty_publikacja
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> numer_wynalazku { get; set; }
        public Nullable<int> id_publikacji { get; set; }
    
        public virtual Patenty Patenty { get; set; }
        public virtual Publikacje Publikacje { get; set; }
    }
}
