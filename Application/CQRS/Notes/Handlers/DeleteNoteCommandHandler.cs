using Application.Abstractions;
using Application.CQRS.Notes.Commands;
using Domain.Abstractions;
using Domain.Exceptions;

namespace Application.CQRS.Notes.Handlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand, Guid>
    {
        private readonly INoteRepository _repository;

        public DeleteNoteCommandHandler(INoteRepository repository) => _repository = repository;

        public async Task<Guid> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            Guid id = await _repository.Delete(request.Id);

            return id;
        }
    }
}
