using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Data.Models
{
    public class BankResponseConfiguration : IEntityTypeConfiguration<BankResponse>
    {
        public void Configure(EntityTypeBuilder<BankResponse> builder)
        {
            builder.GuidIdentity(m => m.BankResponseId);

            builder.Property(m => m.PaymentId);
            builder.Property(m => m.StatusCode);

            builder.HasOne(m => m.Invoice)
                .WithOne(m => m.BankResponse)
                .IsRequired();
        }
    }
}
