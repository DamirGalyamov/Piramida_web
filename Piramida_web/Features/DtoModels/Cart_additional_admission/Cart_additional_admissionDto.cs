using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Cart_additional_admission
{
    public class Cart_additional_admissionDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Cart_product))]
        public Guid Cart_productId { get; set; }

        [Required]
        public Guid AdmissionId { get; set; }
    }
}
