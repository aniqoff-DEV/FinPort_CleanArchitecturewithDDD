using Application.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Configurations
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionTypeEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(TransactionType.MAX_NAME_LENGHT);
        }
    }
}
