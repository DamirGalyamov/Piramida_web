using System.ComponentModel.DataAnnotations;

namespace Piramida_web.Features.DtoModels.Employee
{
    public class EditEmployeeDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Section { get; set; }

    }
}
