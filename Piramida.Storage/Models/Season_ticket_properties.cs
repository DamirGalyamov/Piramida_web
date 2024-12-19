using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Season_ticket_properties
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Season_Ticket))]
        public Guid Season_ticketId { get; set; }

        [Required]
        public Guid Product_propertyId { get; set; }

        public virtual Season_ticket Season_Ticket { get; set; }
    }
}
