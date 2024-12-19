using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Admission
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required, MaxLength(255)]

        public string Status { get; set; }

        public virtual Product Product { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
