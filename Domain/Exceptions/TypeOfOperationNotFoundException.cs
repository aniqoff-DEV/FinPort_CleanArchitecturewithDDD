using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class TypeOfOperationNotFoundException : NotFoundException
    {
        public TypeOfOperationNotFoundException(string name)
        : base($"Operation type named {name} not found.")
        {
        }
    }
}
