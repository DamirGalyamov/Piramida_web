using System.ComponentModel.DataAnnotations;

namespace Piramida_web.Features.DtoModels.Client
{
    public class ClientDto
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
