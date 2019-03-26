using Microsoft.EntityFrameworkCore;
using Motorola.MotoTaxi.Orders.DbServices.Configurations;
using Motorola.MotoTaxi.Orders.DomainModels;
using System;

namespace Motorola.MotoTaxi.Orders.DbServices
{
    //add package Microsoft.EntityFrameworkCore
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>().OwnsOne(p => p.Start);
            //modelBuilder.Entity<Order>().OwnsOne(p => p.Destination);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
