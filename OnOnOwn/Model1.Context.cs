﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnOnOwn
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnOnOwnEntities : DbContext
    {
        public OnOnOwnEntities()
            : base("name=OnOnOwnEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<menu> menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMenu> OrderMenu { get; set; }
        public virtual DbSet<Stol> Stol { get; set; }
        public virtual DbSet<StopList> StopList { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
    }
}
