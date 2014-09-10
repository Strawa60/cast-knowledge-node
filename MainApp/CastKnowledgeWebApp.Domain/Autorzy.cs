

namespace CastKnowledgeWebApp.Domain
{
    using System.Collections.Generic;
    
    public partial class Autorzy
    {
        public Autorzy()
        {
            this.Patent_autor = new HashSet<Patent_autor>();
            this.Publikacja_autor = new HashSet<Publikacja_autor>();
        }


        public int id_autora { get; set; }

        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string afiliacja { get; set; }
        public string funkcja { get; set; }
    
        public virtual ICollection<Patent_autor> Patent_autor { get; set; }
        public virtual ICollection<Publikacja_autor> Publikacja_autor { get; set; }
    }
}
