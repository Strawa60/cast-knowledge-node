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
    
    public partial class Patenty_publikacja
    {
        [Key]
        public int id { get; set; }
        public Nullable<int> numer_wynalazku { get; set; }
        public Nullable<int> id_publikacji { get; set; }
    
        public virtual Patenty Patenty { get; set; }
        public virtual Publikacje Publikacje { get; set; }
    }
}