using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Admission
{
    public class EditAdmissionDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required, MaxLength(255)]

        public string Status { get; set; }

    }
}
