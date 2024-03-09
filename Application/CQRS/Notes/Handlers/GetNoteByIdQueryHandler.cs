using Application.Abstractions;
using Application.CQRS.Notes.Queries;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;

namespace Application.CQRS.Notes.Handlers
{
    public class GetNoteByIdQueryHandler : IQueryHandler<GetNoteByIdQuery, Note>
    {
        private readonly INoteRepository _repository;

        public GetNoteByIdQueryHandler(INoteRepository repository) => _repository = repository;

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var note = await _repository.Get(request.Id);

            if (note is null)
                throw new NoteNotFoundException();

            return note;
        }
    }
}
