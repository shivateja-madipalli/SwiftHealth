﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWcf
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Cmpe285ProjEntities : DbContext
    {
        public Cmpe285ProjEntities()
            : base("name=Cmpe285ProjEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<HealthServiceProvider_Day_Details> HealthServiceProvider_Day_Details { get; set; }
        public DbSet<HealthServiceProvider_Details> HealthServiceProvider_Details { get; set; }
        public DbSet<Patient_Details> Patient_Details { get; set; }
    }
}