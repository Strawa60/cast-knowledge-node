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
    
    public partial class Patent_autor
    {
        public int id { get; set; }
        public Nullable<int> id_autora { get; set; }
        public Nullable<int> numer_wynalazku { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        public virtual Patenty Patenty { get; set; }
    }
}
