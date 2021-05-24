using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data.Models
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.GuidIdentity(m => m.BasketItemId);

            builder.Property(m => m.Quantity)
                .IsRequired();

            builder.HasOne(m => m.Product);
        }
    }
}
