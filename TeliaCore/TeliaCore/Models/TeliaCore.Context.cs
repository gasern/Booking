﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeliaCore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MealOrder> MealOrders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RefreshmentItem> RefreshmentItems { get; set; }
    }
}
