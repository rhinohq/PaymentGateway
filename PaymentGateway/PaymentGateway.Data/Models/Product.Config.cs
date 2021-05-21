using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.GuidIdentity(m => m.ProductId);

            builder.Property(m => m.Name);
            builder.Property(m => m.Description);
            builder.Property(m => m.ImageUrl);
            builder.Property(m => m.Amount);

            builder.HasOne(m => m.Merchant)
                .WithMany(m => m.Products)
                .HasForeignKey(m => m.MerchantId)
                .IsRequired();

            builder.HasData(
                new Product { ProductId = Guid.Parse("C758E8AF-0E04-4111-8FA0-4785280790CD"), Name = "Product A", Description = "You want this really cool product.", Amount = 9.99m, ImageUrl = "/images/prod-a.jpg", MerchantId = Guid.Parse("AC0AE11D-9865-4037-A3F6-BB746B80E1EE") },
                new Product { ProductId = Guid.Parse("C858E8AF-0E04-4111-8FA0-4785280790CD"), Name = "Product B", Description = "You want this really cool product.", Amount = 19.99m, ImageUrl = "/images/prod-b.jpg", MerchantId = Guid.Parse("AC0AE11D-9865-4037-A3F6-BB746B80E1EE") }
            );
        }
    }
}
