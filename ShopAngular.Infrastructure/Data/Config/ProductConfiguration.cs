using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAngular.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAngular.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(180);
            builder.Property(a => a.Price).HasColumnType("decimal(18,2)");
            builder.Property(a => a.PictureUrl).IsRequired();
            builder.HasOne(a => a.ProductBrand).WithMany().HasForeignKey(b => b.ProductBrandId);
            builder.HasOne(a => a.ProductType).WithMany().HasForeignKey(b => b.ProductTypeId);
        }
    }
}
