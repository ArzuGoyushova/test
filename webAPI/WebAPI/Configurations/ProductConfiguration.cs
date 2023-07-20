using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(20);
            builder.Property(p => p.SalePrice).IsRequired(true).HasDefaultValue(20);
            builder.Property(p => p.CostPrice).IsRequired(true).HasDefaultValue(10);
            builder.Property(p => p.CostPrice).HasColumnType("decimal(18,2)");
            //builder.Property(p => p.CreatedDate).HasDefaultValueSql("getutcdate()");
        }
    }
}
