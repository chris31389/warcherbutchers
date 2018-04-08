using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WArcherButchers.ServerApp.Infrastructure.Data;

namespace WArcherButchers.ServerApp.Products
{
    public class ProductEntityTypeConfiguration : EntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
        }
    }
}