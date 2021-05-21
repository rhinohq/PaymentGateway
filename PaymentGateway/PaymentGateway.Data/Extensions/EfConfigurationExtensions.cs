using System;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentGateway.Data.Extensions
{
    public static class EfConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> GuidIdentity<TEntity>(
            this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, object>> propertyExpression) where TEntity : class
        {
            builder.HasKey(propertyExpression);
            builder.Property(propertyExpression)
                .ValueGeneratedOnAdd().HasDefaultValueSql("NEWSEQUENTIALID()");

            return builder;
        }
    }
}
