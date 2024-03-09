using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Entities
{
    public class TransactionTypeEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; }

        [JsonIgnore]
        public List<NoteEntity>? Notes { get; set; }
    }
}
