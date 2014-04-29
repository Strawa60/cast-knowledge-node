//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Dostawca
    {
        public Dostawca()
        {
            this.Dostawca_tagi = new HashSet<Dostawca_tagi>();
            this.Zasoby = new HashSet<Zasoby>();
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
        public Nullable<int> id_term { get; set; }
    
        public virtual ICollection<Dostawca_tagi> Dostawca_tagi { get; set; }
        public virtual Typ_firmy Typ_firmy { get; set; }
        public virtual ICollection<Zasoby> Zasoby { get; set; }
    }
}
