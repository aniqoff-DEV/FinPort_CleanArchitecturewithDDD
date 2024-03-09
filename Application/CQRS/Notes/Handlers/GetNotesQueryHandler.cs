using Application.Abstractions;
using Application.CQRS.Notes.Queries;
using Domain.Abstractions;
using Domain.Models;

namespace Application.CQRS.Notes.Handlers
{
    public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, List<Note>>
    {
        private readonly INoteRepository _repository;
        
        public GetNotesQueryHandler(INoteRepository repository) => _repository = repository;

        public async Task<List<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = await _repository.GetAll();

            return notes;
        }
    }
}
