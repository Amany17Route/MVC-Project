using Company.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Contexts
{
    public class CompanyDbContext2 : DbContext

    {
        public CompanyDbContext2(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server =. ; database=CompanyMVC; trusted_connections =true; TrustServerCertificate=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }


        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department>Departments { get; set; }

    }
}
