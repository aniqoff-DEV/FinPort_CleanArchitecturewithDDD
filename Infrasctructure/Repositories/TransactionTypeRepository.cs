using Application.Entities;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrasctructure.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly FinPortDbContext _context;

        public TransactionTypeRepository(FinPortDbContext context) => _context = context;

        public async Task<Guid> Create(TransactionType type)
        {
            var typeEntity = new TransactionTypeEntity
            {
                Id = type.Id,
                Name = type.Name,
                Color = type.Color,
            };

            await _context.TransactionTypes.AddAsync(typeEntity);
            await _context.SaveChangesAsync();

            return typeEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.TransactionTypes
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<TransactionType> Get(Guid id)
        {
            var currentType = await _context.TransactionTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            if (currentType is not null)
            {
                var (type, error) = TransactionType.Create(
                    currentType.Id,
                    currentType.Name,
                    currentType.Color);

                if (!string.IsNullOrEmpty(error))
                    throw new TypeOfOperationNotFoundException(error);

                return type;
            }
            return null!;
        }

        public async Task<List<TransactionType>> GetAll()
        {
            var typeEntities = await _context.TransactionTypes
                .AsNoTracking()
                .ToListAsync();

            var types = typeEntities
                .Select(t => TransactionType.Create(
                    t.Id,
                    t.Name,
                    t.Color
                    ).TransactionType)
                .ToList();

            return types;
        }

        public async Task<Guid> Update(Guid id, string name, string color)
        {
            await _context.TransactionTypes
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Name, t => name)
                    .SetProperty(t => t.Color, t => color));

            return id;
        }
    }
}
