﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Estudiantil
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class programacion3Entities : DbContext
    {
        public programacion3Entities()
            : base("name=programacion3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aulas> aulas { get; set; }
        public virtual DbSet<materias> materias { get; set; }
        public virtual DbSet<estudiantes> estudiantes { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    }
}
