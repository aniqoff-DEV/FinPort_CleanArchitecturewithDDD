using Application.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.DescriptionNote)
                .HasMaxLength(Note.MAX_DESCRIPTION_LENGHT);

            builder.Property(c => c.Cost)
                .HasPrecision(Note.MAX_COST_PRECISION, Note.MAX_COST_SCALE);
        }
    }
}
