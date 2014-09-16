
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publikacje
    {
        public Publikacje()
        {
            this.Patenty_publikacja = new HashSet<Patenty_publikacja>();
            this.Publikacja_autor = new HashSet<Publikacja_autor>();
            this.Publikacje_tagi = new HashSet<Publikacje_tagi>();
        }
    
        public int id_publikacji { get; set; }
        public string rok_publikacji { get; set; }
        public string tytul_polski { get; set; }
        public string tytul_zagraniczny { get; set; }
        public string streszczenie_pol { get; set; }
        public string streszczenie_ang { get; set; }
        public string zrodlo_publikacji { get; set; }
        public string nr_publikacji { get; set; }
    
        public virtual ICollection<Patenty_publikacja> Patenty_publikacja { get; set; }
        public virtual ICollection<Publikacja_autor> Publikacja_autor { get; set; }
        public virtual ICollection<Publikacje_tagi> Publikacje_tagi { get; set; }
    }
}
