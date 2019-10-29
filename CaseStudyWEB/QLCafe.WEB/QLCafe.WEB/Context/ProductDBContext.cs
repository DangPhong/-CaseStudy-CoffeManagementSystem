using Microsoft.EntityFrameworkCore;
using QLCafe.WEB.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.WEB.Context
{
    public class ProductDBContext : DbContext
    {
        public static string DefaultConnectionString { get; set; }

        public string ConnectionString { get; } = DefaultConnectionString;

        public ProductDBContext(string connectionString = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                this.ConnectionString = connectionString;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsCreate> ProductsAdd { get; set; }

    }
}
