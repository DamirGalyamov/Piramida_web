using System.ComponentModel.DataAnnotations;

namespace Piramida.Storage.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, Phone]
        public string Telephone { get; set; }

        [Required, MaxLength(255)]
        public string Login { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }
    }
}
