using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data.Models
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.GuidIdentity(m => m.BasketId);

            builder.Property(m => m.OwnedByUser)
                .IsRequired();

            builder.HasMany(m => m.Items);
            builder.HasOne(m => m.Invoice)
                .WithOne(m => m.Basket)
                .HasForeignKey<Invoice>(m => m.BasketId);
        }
    }
}
