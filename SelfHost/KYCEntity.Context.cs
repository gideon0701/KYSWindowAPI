﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SelfHost
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KYCAIS_DEVEntities : DbContext
    {
        public KYCAIS_DEVEntities()
            : base("name=KYCAIS_DEVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<doctype> doctypes { get; set; }
        public virtual DbSet<document> documents { get; set; }
        public virtual DbSet<industry> industries { get; set; }
        public virtual DbSet<PersonEntity> PersonEntities { get; set; }
        public virtual DbSet<search_sites> search_sites { get; set; }
        public virtual DbSet<sector> sectors { get; set; }
        public virtual DbSet<entityType> entityTypes { get; set; }
        public virtual DbSet<mainEntity> mainEntities { get; set; }
        public virtual DbSet<newsSubEntity> newsSubEntities { get; set; }
        public virtual DbSet<subEntity> subEntities { get; set; }
    }
}
