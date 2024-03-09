using Application.Abstractions;
using Domain.Models;

namespace Application.CQRS.Notes.Queries
{
    public sealed record GetNoteByIdQuery(Guid Id) : IQuery<Note>;
}
