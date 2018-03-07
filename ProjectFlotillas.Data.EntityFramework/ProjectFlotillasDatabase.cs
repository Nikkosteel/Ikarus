using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFlotillas.Business.Entities;
using System.Data.Entity;

namespace ProjectFlotillas.Data.EntityFramework
{
    /// <summary>
    /// ProjectFlotillas Entity Framework Database Context
    /// </summary>
    public class ProjectFlotillasDatabase : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
      
        /// <summary>
        /// Model Creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("dbo.Customers");
            modelBuilder.Entity<Product>().ToTable("dbo.Products");
         


        }
    }
}
