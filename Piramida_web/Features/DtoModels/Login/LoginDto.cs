using System.ComponentModel.DataAnnotations;

namespace Piramida_web.Features.DtoModels.Login
{
    public class LoginDto
    {

        [Required, MaxLength(255)]
        public string Login { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }
    }
}
