using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Sale_product_property
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Sale))]
        public Guid SaleId { get; set; }

        public Guid PropertyId { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
