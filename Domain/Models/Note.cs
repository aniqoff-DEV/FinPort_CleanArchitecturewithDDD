using Domain.Models;

namespace Domain.Models
{
    public class Note
    {
        public const int MAX_COST_SCALE = 2;
        public const int MAX_COST_PRECISION = 20;

        public const int MAX_DESCRIPTION_LENGHT = 200;
        public const bool ONLY_POSITIVE_COST = true;
        private Note(Guid id, string typeOfOperation, Guid transactionType, string descriptionNote, decimal cost, DateTime createdNote)
        {
            Id = id;
            TypeOfOperation = typeOfOperation;
            TransactionTypeId = transactionType;
            DescriptionNote = descriptionNote;
            Cost = cost;
            CreatedNote = createdNote;
        }

        public Guid Id { get; }
        public string TypeOfOperation { get; } // profit(+) or expense(-)
        public Guid TransactionTypeId { get; } // custom transiction
        public string DescriptionNote { get; } = string.Empty;
        public decimal Cost { get; }
        public DateTime CreatedNote { get; }

        public static (Note Note, string Error) Create
            (Guid id,
            string typeOfOperation,
            Guid transactionType,
            string descriptionNote, 
            decimal cost,
            DateTime createdNote)
        {
            string error = string.Empty;

            if (ONLY_POSITIVE_COST && cost <= 0)
                error += $"{cost} Cost cannot be negative! ";

            if (descriptionNote.Length > MAX_DESCRIPTION_LENGHT)
                error += $"Title can not be longer then {MAX_DESCRIPTION_LENGHT} words. ";

            if (cost.Scale > MAX_COST_SCALE)
                error += $"The cost cannot be longer than {MAX_COST_PRECISION - 2} numbers.";

            var note = new Note(id, typeOfOperation,transactionType, descriptionNote, cost, createdNote);

            return (note, error);
        }
    }
}
