using Domain.Models;

namespace Domain.Abstractions
{
    public interface INoteService
    {
        Task<Note> Delete(Guid id);
        Task<List<Note>> GetAll();
        Task<Note> GetBy(Guid id);
        Task<Note> Insert(
            string typeOfOperation,
            Guid transactionTypeId,
            string descriptionNote,
            decimal cost,
            DateTime createdDate);
        Task<Note> Update(
            Guid id,
            string typeOfOperation,
            Guid transactionTypeId,
            string descriptionNote,
            decimal cost,
            DateTime createdDate);
    }
}