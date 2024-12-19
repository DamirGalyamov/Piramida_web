using System.ComponentModel.DataAnnotations;

namespace Piramida.Storage.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Section { get; set; }
    }
}
