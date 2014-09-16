
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patenty
    {
        public Patenty()
        {
            this.Patent_autor = new HashSet<Patent_autor>();
            this.Patenty_publikacja = new HashSet<Patenty_publikacja>();
            this.Patenty_tagi = new HashSet<Patenty_tagi>();
        }
    
        public int id_patentu { get; set; }
        public string numer_wynalazku { get; set; }
        public string data_rozpoczecia { get; set; }
        public string data_zakonczenia { get; set; }
        public string data_zgloszenia { get; set; }
        public string symbol_patentowy { get; set; }
        public string tytul_polski { get; set; }
        public string tytul_angielski { get; set; }
        public string opis_polski { get; set; }
        public string opis_angielski { get; set; }
        public string osrodek_opracowujacy { get; set; }
        public string url { get; set; }
    
        public virtual ICollection<Patent_autor> Patent_autor { get; set; }
        public virtual ICollection<Patenty_publikacja> Patenty_publikacja { get; set; }
        public virtual ICollection<Patenty_tagi> Patenty_tagi { get; set; }
    }
}
