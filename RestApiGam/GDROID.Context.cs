﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApiGam
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GDROIDEntities : DbContext
    {
        public GDROIDEntities()
            : base("name=GDROIDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DEVICE> DEVICE { get; set; }
        public DbSet<MESSAGE> MESSAGE { get; set; }
        public DbSet<NOTIFICATION> NOTIFICATION { get; set; }
        public DbSet<NOTIFICATION_TYPE> NOTIFICATION_TYPE { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
