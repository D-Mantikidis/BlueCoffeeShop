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
    internal class MonthlyLedgerConfiguration : IEntityTypeConfiguration<MonthlyLedger>
    {
        public void Configure(EntityTypeBuilder<MonthlyLedger> builder)
        {
            builder.ToTable("MonthlyLedger");
            builder.HasKey(monthlyledger => monthlyledger.Id);
            builder.Property(monthlyledger => monthlyledger.Id).ValueGeneratedOnAdd();
        }
    }
}
