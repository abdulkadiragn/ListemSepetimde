using DataAccessLayer.Concrete.Context.EntityFramework.Mapping;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework
{
    public class ListemSepetimdeDbContext : IdentityDbContext<AppUser,AppRole,int> //senin oluşturdugun identityUser : AppUser identityRole : AppRole olsun. Keyleri de int.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ListemSepetimdeDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //database'de tablo ilişkilerinde Delete Rule hepsinde Cascade geliyor. Bunu no action'a çekmek için aşşağıdaki foreach kullanıldı.
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId }); //çoka çok tabloların keylerini belirlemek için.
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductImageMap());
            modelBuilder.Entity<AppRole>().HasData
                (
                    new AppRole { Id=1,Name="Admin",NormalizedName="ADMIN"},
                    new AppRole { Id=2,Name="UserApp",NormalizedName="USERAPP"}
                );
            base.OnModelCreating(modelBuilder);
        }
        //tablolar
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductCategory>  ProductCategory { get; set; }
        public DbSet<Basket> Basket { get; set; }

    }
}
