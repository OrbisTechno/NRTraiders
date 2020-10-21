using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NRTraiders.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Display(Name = "Item Description")]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int ItemTypeId { get; set; }
    }
}
