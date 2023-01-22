using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Проект.Models;


namespace Проект.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
           : base("MyStore")
        { }

        public DbSet<Auth> Authes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
