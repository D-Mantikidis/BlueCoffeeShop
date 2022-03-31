using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Id).ValueGeneratedOnAdd();
            builder.HasOne(product => product.ProductCategory).WithMany(productCategory => productCategory.Products).HasForeignKey(productCategory => productCategory.Id);
            builder.Property(product => product.Code).HasMaxLength(30);
            builder.Property(product => product.Description).HasMaxLength(60);
        }
    }
}
