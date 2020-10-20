using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NRTraiders.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public  string UserPassword { get; set; }

        [NotMapped]
        [Compare("UserPassword")]
        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
