using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Product_property
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

        public virtual Product Product { get; set; }
    }
}
