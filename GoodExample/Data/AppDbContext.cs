using EasySale.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EasySale.Data
{
    public class AppDbContext : DbContext
    {
    //    public IDbSet<project_tb> projects { get; set; }
        public AppDbContext()   : base("AppDbContext")
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<stock_tb> stocks { get; set; }

        public DbSet<price_tb> prices { get; set; }

        public DbSet<salesDetail_tb> sales { get; set; }

        public DbSet<creditAccount_tb> creditDetails { get; set; }

        public DbSet<customer_tb> customers { get; set; }

        public DbSet<catagory_tb> categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<price_tb>()
            .HasKey(e => e.stock_id);

            modelBuilder.Entity<stock_tb>()
            .HasRequired(s => s.prices)
            .WithRequiredPrincipal(ad => ad.stocks);
        }
    }


}