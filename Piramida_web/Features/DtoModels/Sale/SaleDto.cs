using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Sale
{
    public class SaleDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [Required]
        public double Sale_procent { get; set; }

        [Required]
        public double Total_price { get; set; }
    }
}
