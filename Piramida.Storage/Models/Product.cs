﻿using System.ComponentModel.DataAnnotations;

namespace Piramida.Storage.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; } = 0;

        [Required]
        public string Short_description { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]

        public string Category { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
