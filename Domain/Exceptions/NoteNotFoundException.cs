using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class NoteNotFoundException : NotFoundException
    {
        public NoteNotFoundException()
        : base($"Note transaction not found..")
        {
        }
    }
}
