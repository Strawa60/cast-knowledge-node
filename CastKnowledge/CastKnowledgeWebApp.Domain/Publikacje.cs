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
    
    public partial class Publikacje
    {
        public Publikacje()
        {
            this.Patenty_publikacja = new HashSet<Patenty_publikacja>();
            this.Publikacja_autor = new HashSet<Publikacja_autor>();
            this.Publikacje_tagi = new HashSet<Publikacje_tagi>();
        }

        [Key]
        public int id_publikacji { get; set; }
        public string rok_publikacji { get; set; }
        public string tytul_polski { get; set; }
        public string tytul_zagraniczny { get; set; }
        public string streszczenie_pol { get; set; }
        public string streszczenie_ang { get; set; }
        public string zrodlo_publikacji { get; set; }
    
        public virtual ICollection<Patenty_publikacja> Patenty_publikacja { get; set; }
        public virtual ICollection<Publikacja_autor> Publikacja_autor { get; set; }
        public virtual ICollection<Publikacje_tagi> Publikacje_tagi { get; set; }
    }
}
