using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odlewnia
    {
        public Odlewnia()
        {
            this.Technologia = new HashSet<Technologia>();
            this.Odlewnia_tagi = new HashSet<Odlewnia_tagi>();
            this.Tworzywo = new HashSet<Tworzywo>();
        }
    [Key]
        public int id_odlewni { get; set; }
        public string nazwa { get; set; }
        public string miejscowosc { get; set; }
        public string kod_pocztowy { get; set; }
        public string ulica { get; set; }
        public string telefon { get; set; }
        public string fax { get; set; }
        public string www { get; set; }
        public string e_mail { get; set; }
    
        public virtual ICollection<Technologia> Technologia { get; set; }
        public virtual ICollection<Odlewnia_tagi> Odlewnia_tagi { get; set; }
        public virtual ICollection<Tworzywo> Tworzywo { get; set; }
    }
}
