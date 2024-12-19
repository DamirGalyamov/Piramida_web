using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Cart_additional_property
{
    public class EditCart_additional_propertyDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Cart_product))]
        public Guid Cart_productId { get; set; }

        [Required]
        public Guid Product_propertyId { get; set; }

    }
}
