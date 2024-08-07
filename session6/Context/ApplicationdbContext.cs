using Microsoft.EntityFrameworkCore;
using session6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session6.Context
{
    internal class ApplicationdbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ASP9_EF;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
