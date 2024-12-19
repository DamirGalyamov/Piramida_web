using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Cart_product
{
    public class EditCart_productDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Cart))]

        public Guid CartId { get; set; }

        public double count { get; set; }

    }
}
