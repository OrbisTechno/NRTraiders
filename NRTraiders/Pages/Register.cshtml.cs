using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {

            var appUer = AppUser;
        }

    }
}
