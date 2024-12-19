using System.ComponentModel.DataAnnotations;

namespace Piramida_web.Features.DtoModels.Feedback
{
    public class EditFeedbackDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Phone]
        public string Telephone { get; set; }

        [Required]
        public string question { get; set; }

    }
}
