using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class SeaportContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                        Database=SeaportDb;Trusted_Connection=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Shipowner> Shipowners { get; set; }
        public DbSet<ShipType> ShipTypes { get; set; }

    }
}