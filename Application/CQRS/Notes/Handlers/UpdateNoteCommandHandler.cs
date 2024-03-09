using Application.CQRS.Notes.Commands;
using Application.Abstractions;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;

namespace Application.CQRS.Notes.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand, Guid>
    {
        private readonly INoteRepository _repository;

        public UpdateNoteCommandHandler(INoteRepository repository) => _repository = repository;

        public async Task<Guid> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var (nameTypeOfOperation, errorNameType) = TypeOfOperation.Check(request.TypeOfOperation);

            if (!string.IsNullOrEmpty(errorNameType))
                throw new TypeOfOperationNotFoundException(errorNameType);

            var (note, error) = Note.Create(
                Guid.NewGuid(),
                nameTypeOfOperation.Name,
                request.TransactionTypeId,
                request.DescriptionNote,
                request.Cost,
                 request.CreatedNote);

            if (!string.IsNullOrEmpty(error))
                throw new NoteBadRequestException(error);

            Guid id = await _repository.Update(
                request.Id,
                note.TypeOfOperation,
                note.TransactionTypeId,
                note.DescriptionNote,
                note.Cost,
                note.CreatedNote);

            return id;
        }
    }
}
