﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piramida.Storage.Models
{
    public class Cart_additional_admission
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Cart_Product))]
        public Guid Cart_productId { get; set; }

        [Required]
        public Guid AdmissionId { get; set; }

        public virtual Cart_product Cart_Product { get; set; }
    }
}