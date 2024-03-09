using Application.Abstractions;
using Domain.Models;

namespace Application.CQRS.Notes.Queries
{
    public sealed record GetNotesQuery() : IQuery<List<Note>>;
}
