using Application.Abstractions;

namespace Application.CQRS.Notes.Commands
{
    public sealed record CreateNoteCommand(
        string TypeOfOperation,
        Guid TransactionTypeId,
        string DescriptionNote,
        decimal Cost,
        DateTime CreatedNote) : ICommand<Guid>;
}
