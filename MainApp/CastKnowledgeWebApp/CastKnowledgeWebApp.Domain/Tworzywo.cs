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
    
    public partial class Tworzywo
    {
        [Key]
        public int id_tworzywo { get; set; }
        public string nazwa_tworzywa { get; set; }
        public Nullable<int> id_odlewni { get; set; }
    
        public virtual Odlewnia Odlewnia { get; set; }
    }
}
