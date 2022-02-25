using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework.Mapping
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder
                .HasOne(x => x.Product) //tek olan hangisi
                .WithMany(x => x.ProductImages) //çok olacak hangisi
                .HasForeignKey(x => x.ProductId);
        }
    }
}
