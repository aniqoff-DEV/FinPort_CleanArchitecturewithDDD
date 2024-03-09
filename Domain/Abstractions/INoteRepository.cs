using Domain.Models;

namespace Domain.Abstractions
{
    public interface INoteRepository
    {
        Task<Guid> Create(Note note);
        Task<Guid> Delete(Guid id);
        Task<List<Note>> GetAll();
        Task<Note> Get(Guid id);
        Task<Guid> Update(Guid id, string typeOfOperation, Guid transactionType, string descriptionNote, decimal cost, DateTime createdNote);
    }
}
