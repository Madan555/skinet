using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(d=>d.Price).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.HasOne(h=>h.ProductBrand).WithMany().HasForeignKey(f=>f.ProductBrandId);
            builder.HasOne(h=>h.ProductType).WithMany().HasForeignKey(f=>f.ProductTypeId);
        }
    }
}