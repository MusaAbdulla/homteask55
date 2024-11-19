using Efcore2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efcore2.Context
{
    public class AppDbcontext :DbContext
    {
        public DbSet<Baskets> baskets { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= .\\SQLEXPRESS;DataBase=Abbb108;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
