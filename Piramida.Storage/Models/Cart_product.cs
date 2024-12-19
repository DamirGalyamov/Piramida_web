using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Cart_product
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Carts))]

        public Guid CartId { get; set; }

        public double count { get; set; }

        public virtual Product Product { get; set; }

        public virtual Cart Carts { get; set; }
    }
}
