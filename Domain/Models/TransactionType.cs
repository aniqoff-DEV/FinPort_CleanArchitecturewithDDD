namespace Domain.Models
{
    public class TransactionType
    {
        public const int MAX_NAME_LENGHT = 50;
        private TransactionType(Guid id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Color { get; }

        public static (TransactionType TransactionType, string Error) Create
            (Guid id,
            string name, 
            string color)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGHT)
                error += $"Name can not be empty or longer then {MAX_NAME_LENGHT} words";

            var transactionType = new TransactionType(id, name, color);

            return (transactionType, error);
        }
    }
}
