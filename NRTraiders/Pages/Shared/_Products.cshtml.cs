using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages.Shared
{
    public class _ProductsModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public _ProductsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<string> Animals = new List<string>();
        public void OnGet()
        {
            Animals.AddRange(new[] { "Antelope", "Badger", "Cat", "Dog" });
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var productFromDb = await _db.Product.FindAsync(id);

            _db.Product.Remove(productFromDb);
            await _db.SaveChangesAsync();

            return Page();
        }

        public void OnPostDelete()
        {

        }
    }
}
