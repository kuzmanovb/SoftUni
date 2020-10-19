using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andreys.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        
        [Required]
        public Category Category { get; set; }
        
        [Required]
        public Gender Gender { get; set; }
    }
}
