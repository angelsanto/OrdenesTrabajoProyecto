﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENTIDAD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BSORDENTRABAJOEntities : DbContext
    {
        public BSORDENTRABAJOEntities()
            : base("name=BSORDENTRABAJOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TIPOSERVICIO> TIPOSERVICIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<CARGO> CARGO { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADO { get; set; }
        public virtual DbSet<SOLIORDEN> SOLIORDEN { get; set; }
        public virtual DbSet<TRABAJOSREALIZADOS> TRABAJOSREALIZADOS { get; set; }
        public virtual DbSet<MANTENIMIENTO> MANTENIMIENTO { get; set; }
        public virtual DbSet<ORDENTRABAJO> ORDENTRABAJO { get; set; }
        public virtual DbSet<MATERIALES> MATERIALES { get; set; }
        public virtual DbSet<DETALLEORDEN> DETALLEORDEN { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    }
}
