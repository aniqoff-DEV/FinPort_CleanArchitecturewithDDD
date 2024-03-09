using Domain.Models;

namespace Infrasctructure.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task<Guid> Create(TransactionType type);
        Task<Guid> Delete(Guid id);
        Task<TransactionType> Get(Guid id);
        Task<List<TransactionType>> GetAll();
        Task<Guid> Update(Guid id, string name, string color);
    }
}