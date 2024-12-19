using System.ComponentModel.DataAnnotations;

namespace Piramida.Storage.Models
{
    public class ImagesForSpailn
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Titel { get; set; }

        [Required, MaxLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, MaxLength(255)]
        public string link { get; set; }
    }
}
