using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NRTraiders.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display( Name = "Product Name" )]
        public string Name { get; set; }

        [Display(Name="Product Description")]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
