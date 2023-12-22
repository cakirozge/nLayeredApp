using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected IConfiguration Configuration { get; set; } // Configuration: upsettingi apideki okumaya yarar.
        public DbSet<Product> Products { get; set; } //DbSet: Mapping
        public NorthwindContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions) 
        { 
            Configuration = configuration; 
            Database.EnsureCreated(); //veri tabanını yönetecek
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //model yönetecek
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }


    }
}
