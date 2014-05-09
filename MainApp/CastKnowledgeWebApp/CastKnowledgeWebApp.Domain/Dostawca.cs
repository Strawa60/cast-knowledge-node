using System.ComponentModel.DataAnnotations;
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dostawca
    {
        public Dostawca()
        {
            this.Dostawca_tagi = new HashSet<Dostawca_tagi>();
        }
    [Key]
        public int id_firmy { get; set; }
        public string nazwa { get; set; }
        public string miejscowosc { get; set; }
        public string kod_pocztowy { get; set; }
        public string ulica { get; set; }
        public string wojewodztwo { get; set; }
        public string telefon { get; set; }
        public string fax { get; set; }
        public string www { get; set; }
        public string e_mail { get; set; }
        public string prezes { get; set; }
        public string zasoby { get; set; }
        public string typ_firmy { get; set; }
    
        public virtual ICollection<Dostawca_tagi> Dostawca_tagi { get; set; }
    }
}
