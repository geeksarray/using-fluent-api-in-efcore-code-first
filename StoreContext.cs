using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.DataModels;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sales");
            modelBuilder.Entity<Category>().ToTable("GeekCategories");
            
            modelBuilder.Entity<Category>().HasKey(t => t.CategoryID);


            modelBuilder.Entity<Product>().HasKey(t => new { t.CategoryID, t.ProductID });
            modelBuilder.Entity<Product>().Property(t => t.ProductName).HasMaxLength(50);
        }

        #region properties
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
