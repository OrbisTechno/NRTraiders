using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public AppUser AppUser { get; set; }

        public ApplicationDbContext _db { get; set; }

        public RegisterModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == true)
            {
                var appUer = AppUser;

                _db.Add(AppUser);
                _db.SaveChanges();
                return RedirectToPage("Privacy");
            }
            else
            {
                return Page();
            }
        }

    }
}
