using Domain.Exceptions;

namespace Domain.Models
{
    public class TypeOfOperation
    {
        public static readonly List<string> TYPES = (List<string>)Enum.GetValues(typeof(OperationType)).Cast<string>();
        private enum OperationType
        {
            Profit,
            Expense
        }

        private TypeOfOperation(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static (TypeOfOperation TypeOfOperationName, string Error) Check(string name)
        {
            var isOperationType = TYPES.FirstOrDefault(name);
            var error = string.Empty;

            if (isOperationType is null)
                error = name;

            var typeOfOperation = new TypeOfOperation(name);

            return (typeOfOperation, error);
        }
    }
}
