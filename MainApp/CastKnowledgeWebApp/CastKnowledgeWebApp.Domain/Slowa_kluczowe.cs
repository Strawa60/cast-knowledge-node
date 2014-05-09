using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Slowa_kluczowe
    {
        public Slowa_kluczowe()
        {
            this.Dostawca_tagi = new HashSet<Dostawca_tagi>();
            this.Odlewnia_tagi = new HashSet<Odlewnia_tagi>();
            this.Patenty_tagi = new HashSet<Patenty_tagi>();
            this.Publikacje_tagi = new HashSet<Publikacje_tagi>();
        }
    [Key]
        public int id_deskryptora { get; set; }
        public string nazwa { get; set; }
    
        public virtual ICollection<Dostawca_tagi> Dostawca_tagi { get; set; }
        public virtual ICollection<Odlewnia_tagi> Odlewnia_tagi { get; set; }
        public virtual ICollection<Patenty_tagi> Patenty_tagi { get; set; }
        public virtual ICollection<Publikacje_tagi> Publikacje_tagi { get; set; }
    }
}
