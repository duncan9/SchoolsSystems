﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace schoolsSystems.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EMEntities : DbContext
    {
        public EMEntities()
            : base("name=EMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<School> School { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<FormLetter> FormLetter { get; set; }
        public DbSet<SchoolForm> SchoolForm { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<News> News { get; set; }
    }
}
