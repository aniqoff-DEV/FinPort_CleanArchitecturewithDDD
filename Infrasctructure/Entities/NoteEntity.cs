using System.ComponentModel.DataAnnotations;

namespace Application.Entities
{
    public class NoteEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string TypeOfOperation { get; set; }

        public TransactionTypeEntity? TransactionType { get; set; }
        public Guid TransactionTypeId { get; set; }

        [Required]
        public string DescriptionNote { get; set; } = string.Empty;

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public DateTime CreatedNote { get; set; }
    }
}
