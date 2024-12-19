using System.ComponentModel.DataAnnotations;

namespace Piramida.Storage.Models
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Phone]
        public string Telephone { get; set; }

        [Required]
        public string question { get; set; }
    }
}
