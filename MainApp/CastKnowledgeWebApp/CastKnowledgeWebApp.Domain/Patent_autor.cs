using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patent_autor
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> id_autora { get; set; }
        public Nullable<int> numer_wynalazku { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        public virtual Patenty Patenty { get; set; }
    }
}
