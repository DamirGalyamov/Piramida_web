using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida_web.Features.DtoModels.Cart
{
    public class EditCartDto
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Client))]

        public Guid ClientId { get; set; }

    }
}
