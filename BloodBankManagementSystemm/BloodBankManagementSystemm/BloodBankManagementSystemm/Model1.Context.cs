﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBankManagementSystemm
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_BloodBankEntities : DbContext
    {
        public DB_BloodBankEntities()
            : base("name=DB_BloodBankEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblBlood> TblBloods { get; set; }
        public virtual DbSet<TblDonor> TblDonors { get; set; }
        public virtual DbSet<TBLEmployee> TBLEmployees { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TBLTransfer> TBLTransfers { get; set; }
    }
}