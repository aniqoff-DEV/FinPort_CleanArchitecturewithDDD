using Domain.Models;

namespace Domain.Abstractions
{
    public interface ITransactionTypeService
    {
        Task<TransactionType> Create(TransactionType type);
        Task<TransactionType> Delete(Guid id);
        Task<TransactionType> Get(Guid id);
        Task<List<TransactionType>> GetAll();
        Task<TransactionType> Update(TransactionType type);
    }
}
