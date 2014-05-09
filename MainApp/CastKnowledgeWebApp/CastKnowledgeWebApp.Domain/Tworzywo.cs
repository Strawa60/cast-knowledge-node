using System.ComponentModel.DataAnnotations;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tworzywo
    {
        [Key]
        public int id_tworzywo { get; set; }
        public string nazwa_tworzywa { get; set; }
        public Nullable<int> id_odlewni { get; set; }
    
        public virtual Odlewnia Odlewnia { get; set; }
    }
}
