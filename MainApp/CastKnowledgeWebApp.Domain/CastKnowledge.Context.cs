﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CastKnowledgeEntities : DbContext
    {
        public CastKnowledgeEntities()
            : base("name=CastKnowledgeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Autorzy> autorzy { get; set; }
        public DbSet<Dostawca> dostawca { get; set; }
        public DbSet<Dostawca_tagi> dostawca_tagi { get; set; }
        public DbSet<Odlewnia> odlewnia { get; set; }
        public DbSet<Odlewnia_tagi> odlewnia_tagi { get; set; }
        public DbSet<Patent_autor> patent_autor { get; set; }
        public DbSet<Patenty> patenty { get; set; }
        public DbSet<Patenty_publikacja> patenty_publikacja { get; set; }
        public DbSet<Patenty_tagi> patenty_tagi { get; set; }
        public DbSet<Publikacja_autor> publikacja_autor { get; set; }
        public DbSet<Publikacje> publikacje { get; set; }
        public DbSet<Publikacje_tagi> publikacje_tagi { get; set; }
        public DbSet<Slowa_kluczowe> slowa_kluczowe { get; set; }
        public DbSet<Technologia> technologia { get; set; }
        public DbSet<Tworzywo> tworzywo { get; set; }
    }
}
