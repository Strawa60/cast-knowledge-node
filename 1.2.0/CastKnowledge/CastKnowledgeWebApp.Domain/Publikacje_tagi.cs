
namespace CastKnowledgeWebApp.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publikacje_tagi
    {
        public int id { get; set; }
        public Nullable<int> id_publikacji { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
    
        public virtual Publikacje Publikacje { get; set; }
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
    }
}
