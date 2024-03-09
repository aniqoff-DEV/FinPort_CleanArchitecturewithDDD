using Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrasctructure
{
    public class FinPortDbContext : DbContext
    {
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<TransactionTypeEntity> TransactionTypes { get; set; }

        public FinPortDbContext(DbContextOptions<FinPortDbContext> options)
            : base(options)
        {
        }
    }
}
