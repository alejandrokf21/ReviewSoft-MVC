﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReviewSoftMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class REVIEWSOFTEntities : DbContext
    {
        public REVIEWSOFTEntities()
            : base("name=REVIEWSOFTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<DETALLE> DETALLE { get; set; }
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        public virtual DbSet<METRICA> METRICA { get; set; }
        public virtual DbSet<PROFESION> PROFESION { get; set; }
        public virtual DbSet<RETROALIMENTACION> RETROALIMENTACION { get; set; }
        public virtual DbSet<SOFTWARE> SOFTWARE { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIPO_LICENCIA> TIPO_LICENCIA { get; set; }
        public virtual DbSet<TIPO_PLATAFORMA> TIPO_PLATAFORMA { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}