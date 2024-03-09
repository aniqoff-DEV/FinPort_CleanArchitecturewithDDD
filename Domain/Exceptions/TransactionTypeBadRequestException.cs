using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class TransactionTypeBadRequestException : BadRequestException
    {
        public TransactionTypeBadRequestException(string name)
        : base(name)
        {
        }
    }
}
