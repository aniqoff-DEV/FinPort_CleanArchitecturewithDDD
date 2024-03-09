using Application.Abstractions;
using Application.CQRS.Notes.Commands;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;

namespace Application.CQRS.Notes.Handlers
{
    public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, Guid>
    {
        private readonly INoteRepository _repository;

        public CreateNoteCommandHandler(INoteRepository repository) => _repository = repository;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var (nameTypeOfOperation, errorNameType) = TypeOfOperation.Create(request.TypeOfOperation);

            if(!string.IsNullOrEmpty(errorNameType))
                throw new TypeOfOperationNotFoundException(errorNameType);

            var (note,error) = Note.Create(
                Guid.NewGuid(),
                nameTypeOfOperation.Name,
                request.TransactionTypeId,
                request.DescriptionNote,
                request.Cost,
                 request.CreatedNote);

            if(!string.IsNullOrEmpty(error))
                throw new NoteBadRequestException(error);

            await _repository.Create(note);

           return note.Id;
        }
    }
}
