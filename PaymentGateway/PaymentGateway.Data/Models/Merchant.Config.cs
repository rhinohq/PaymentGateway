using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.GuidIdentity(m => m.MerchantId);

            builder.Property(m => m.Name);
            builder.Property(m => m.ImageUrl);

            builder.HasMany(m => m.Products)
                .WithOne(m => m.Merchant)
                .HasForeignKey(m => m.MerchantId)
                .IsRequired();

            builder.HasData(
                new Merchant { MerchantId = Guid.Parse("AC0AE11D-9865-4037-A3F6-BB746B80E1EE"), Name = "Merchant A", ImageUrl = "/images/merch-a.jpg" }
            );
        }
    }
}
