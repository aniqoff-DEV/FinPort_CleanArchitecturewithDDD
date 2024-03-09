using Application.Abstractions;

namespace Application.CQRS.Notes.Commands
{
    public sealed record DeleteNoteCommand(Guid Id) : ICommand<Guid>;
}
