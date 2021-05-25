using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data.Models
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.GuidIdentity(m => m.InvoiceId);

            builder.Property(m => m.FullName);
            builder.Property(m => m.Email);

            builder.Property(m => m.NameOnCard);
            builder.Property(m => m.CardNumber);
            builder.Property(m => m.Cvv);

            builder.Property(m => m.ExpiryMonth);
            builder.Property(m => m.ExpiryYear);

            builder.Property(m => m.Address);
            builder.Property(m => m.City);
            builder.Property(m => m.State);
            builder.Property(m => m.Zip);

            builder.HasOne(m => m.Basket)
                .WithOne(m => m.Invoice)
                .IsRequired();

            builder.HasOne(m => m.BankResponse)
                .WithOne(m => m.Invoice)
                .HasForeignKey<BankResponse>(m => m.InvoiceId)
                .IsRequired();
        }
    }
}