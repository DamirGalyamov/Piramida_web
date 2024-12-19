using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Product_property
{
    public class EditProduct_propertyDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [Required, MaxLength(255)]
        public string Name_of_property { get; set; }

        [Required]

        public string Description_of_property { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
