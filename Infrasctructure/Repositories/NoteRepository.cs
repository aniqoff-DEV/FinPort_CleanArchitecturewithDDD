using Application.Entities;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrasctructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly FinPortDbContext _context;

        public NoteRepository(FinPortDbContext context) => _context = context;

        public async Task<Guid> Create(Note note)
        {
            var noteEntity = new NoteEntity
            {
                Id = note.Id,
                DescriptionNote = note.DescriptionNote,
                TypeOfOperation = note.TypeOfOperation,
                TransactionTypeId = note.TransactionTypeId,
                Cost = note.Cost,
                CreatedNote = note.CreatedNote,
            };

            await _context.Notes.AddAsync(noteEntity);
            await _context.SaveChangesAsync();

            return noteEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Notes
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<Note> Get(Guid id) 
        {
            var currentNote = await _context.Notes
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            if(currentNote is not null)
            {
                var (note, error) = Note.Create(
                    currentNote.Id,
                    currentNote.TypeOfOperation,
                    currentNote.TransactionTypeId,
                    currentNote.DescriptionNote,
                    currentNote.Cost,
                    currentNote.CreatedNote);

                if (!string.IsNullOrEmpty(error))
                    throw new NoteBadRequestException(error);

                return note;
            }
            return null!;
        }

        public async Task<List<Note>> GetAll()
        {
            var noteEntities = await _context.Notes
                .AsNoTracking()
                .ToListAsync();

            var notes = noteEntities
                .Select(b => Note.Create(
                    b.Id,
                    b.TypeOfOperation,
                    b.TransactionTypeId,
                    b.DescriptionNote
                    ,b.Cost,
                    b.CreatedNote).Note)
                .ToList();

            return notes;
        }

        public async Task<Guid> Update(Guid id, string typeOfOperation, Guid transactionType, string descriptionNote, decimal cost, DateTime createdNote)
        {
            await _context.Notes
                .Where(n => n.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(n => n.DescriptionNote, n => descriptionNote)
                    .SetProperty(n => n.TypeOfOperation, n => typeOfOperation)
                    .SetProperty(n => n.TransactionTypeId, n => transactionType)
                    .SetProperty(n => n.Cost, n => cost)
                    .SetProperty(n => n.CreatedNote, n => createdNote));

            return id;
        }
    }
}
