using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Technologia
    {
        [Key]
        public int id_technologia { get; set; }
        public string nazwa_technologii { get; set; }
        public Nullable<int> id_odlewni { get; set; }
    
        public virtual Odlewnia Odlewnia { get; set; }
    }
}
