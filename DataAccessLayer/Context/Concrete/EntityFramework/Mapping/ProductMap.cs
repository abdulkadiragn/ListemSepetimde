using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework.Mapping
{
   public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Product_Name").HasColumnType("nvarchar(50)").IsRequired(); //boş geçilemez kolon adı: product_name olsun
            builder.HasIndex(x => x.Name).IsUnique(); //name'i indexle ve uniq olsun.
            builder
                .HasMany(x => x.ProductImages) //çok olan-geçen hangisi
                .WithOne(x => x.Product) //tek olan hangisi
                .HasForeignKey(x => x.ProductId); //diğer tablodaki primarykey olan foreignkey'i var

        }
    }
}
