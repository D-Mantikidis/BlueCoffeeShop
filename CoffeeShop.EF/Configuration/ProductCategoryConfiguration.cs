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
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(productCategory => productCategory.Id);
            builder.Property(productCategory => productCategory.Id).ValueGeneratedOnAdd();
            builder.Property(productCategory => productCategory.Code).HasMaxLength(100);
            builder.Property(productCategory => productCategory.Description).HasMaxLength(100);

        }
    }
}
