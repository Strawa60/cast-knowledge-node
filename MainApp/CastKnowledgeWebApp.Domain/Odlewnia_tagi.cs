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
    
    public partial class Odlewnia_tagi
    {
        public int id { get; set; }
        public Nullable<int> id_odlewni { get; set; }
        public Nullable<int> id_deskryptora { get; set; }
    
        public virtual Slowa_kluczowe Slowa_kluczowe { get; set; }
        public virtual Odlewnia Odlewnia { get; set; }
    }
}
