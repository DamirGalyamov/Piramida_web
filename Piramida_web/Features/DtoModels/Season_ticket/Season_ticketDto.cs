using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Season_ticket
{
    public class Season_ticketDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Client))]

        public Guid ClientId { get; set; }

        [Required]
        public DateTime Time_of_purchase { get; set; }
    }
}
