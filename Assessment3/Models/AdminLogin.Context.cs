﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assessment3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CDACEntities1 : DbContext
    {
        public CDACEntities1()
            : base("name=CDACEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Priyanka_Admin> Priyanka_Admin { get; set; }
        public virtual DbSet<Priyanka_New_Customer_Registrations> Priyanka_New_Customer_Registrations { get; set; }
    }
}
