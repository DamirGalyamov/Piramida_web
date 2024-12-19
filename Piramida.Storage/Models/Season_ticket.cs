using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Season_ticket
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Client))]

        public Guid ClientId { get; set; }

        [Required]
        public DateTime Time_of_purchase { get; set; }


        public virtual Product Product { get; set; }

        public virtual Client Client { get; set; }
    }
}
