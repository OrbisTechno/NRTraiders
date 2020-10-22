using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRTraiders.Data;

namespace NRTraiders.Pages.Shared
{
    public class _ItemsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public _ItemsModel(ApplicationDbContext db)
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
            var ItemFromDb = await _db.Item.FindAsync(id);

            _db.Item.Remove(ItemFromDb);
            await _db.SaveChangesAsync();

            return Page();
        }

        public void OnPostDelete()
        {

        }
    }
}
