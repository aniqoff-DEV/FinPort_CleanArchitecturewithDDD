using Application.CQRS.Notes.Commands;
using Application.CQRS.Notes.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IMediator _mediator;

        public NoteService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Note>> GetAll()
        {
            return await _mediator.Send(new GetNotesQuery());
        }

        public async Task<Note> GetBy(Guid id)
        {
            return await _mediator.Send(new GetNoteByIdQuery(id));
        }

        public async Task<Note> Delete(Guid id)
        {
            Guid noteId = await _mediator.Send(new DeleteNoteCommand(id));

            return await _mediator.Send(new GetNoteByIdQuery(noteId));
        }

        public async Task<Note> Insert(
            string typeOfOperation, 
            Guid transactionTypeId,
            string descriptionNote,
            decimal cost,
            DateTime createdDate)
        {
            Guid noteId = await _mediator.Send(new CreateNoteCommand(
                typeOfOperation,
                transactionTypeId,
                descriptionNote,
                cost,
                createdDate));

            return await _mediator.Send(new GetNoteByIdQuery(noteId));
        }

        public async Task<Note> Update(
            Guid id,
            string typeOfOperation,
            Guid transactionTypeId,
            string descriptionNote,
            decimal cost,
            DateTime createdDate)
        {
            Guid noteId = await _mediator.Send(new UpdateNoteCommand(
                id,
                typeOfOperation,
                transactionTypeId,
                descriptionNote,
                cost,
                createdDate));

            return await _mediator.Send(new GetNoteByIdQuery(noteId));
        }
    }
}
