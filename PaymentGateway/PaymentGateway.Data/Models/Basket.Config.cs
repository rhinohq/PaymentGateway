using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.GuidIdentity(m => m.BasketId);

            builder.Property(m => m.OwnedByUser)
                .IsRequired();

            builder.HasMany(m => m.Products);
        }
    }
}
