using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class NoteBadRequestException : BadRequestException
    {
        public NoteBadRequestException(string errorMessage)
        : base($"Bad Note! {errorMessage}")
        {
        }
    }
}
