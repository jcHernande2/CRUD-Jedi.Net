﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPrueba.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliotecaEntities : DbContext
    {
        public BibliotecaEntities()
            : base("name=BibliotecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Holograma> Holograma { get; set; }
        public virtual DbSet<HologramaJedi> HologramaJedi { get; set; }
        public virtual DbSet<Jedis> Jedis { get; set; }
    }
}
