﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasoEstudio2Api
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CasoEstudioMNEntities : DbContext
    {
        public CasoEstudioMNEntities()
            : base("name=CasoEstudioMNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CasasSistema> CasasSistema { get; set; }
    
        public virtual ObjectResult<ConsultarCasas_Result> ConsultarCasas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarCasas_Result>("ConsultarCasas");
        }
    }
}
