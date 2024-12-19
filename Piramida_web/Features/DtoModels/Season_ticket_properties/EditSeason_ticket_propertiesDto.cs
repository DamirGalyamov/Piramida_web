using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Season_ticket_properties
{
    public class EditSeason_ticket_propertiesDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Season_ticket))]
        public Guid Season_ticketId { get; set; }

        [Required]
        public Guid Product_propertyId { get; set; }

    }
}
