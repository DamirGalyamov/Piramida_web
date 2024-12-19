using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Sale_product_property
{
    public class Sale_product_propertyDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Sale))]
        public Guid SaleId { get; set; }

        public Guid PropertyId { get; set; }
    }
}
