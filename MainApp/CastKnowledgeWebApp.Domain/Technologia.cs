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
    
    public partial class Technologia
    {
        public int id_technologia { get; set; }
        public string nazwa_technologii { get; set; }
        public Nullable<int> id_odlewni { get; set; }
    
        public virtual Odlewnia Odlewnia { get; set; }
    }
}
