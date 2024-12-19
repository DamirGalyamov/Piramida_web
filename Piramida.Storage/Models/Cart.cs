using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]

        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
