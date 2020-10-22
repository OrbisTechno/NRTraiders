using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class ItemsListModel : PageModel
    {
        public List<Item> Items = new List<Item>();

        [BindProperty]
        public Item Item { get; set; }



        private readonly ApplicationDbContext _db;
        public ItemsListModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task OnGet(int id)
        {
            Items = await _db.Item.Where(x => x.ItemTypeId == id).ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ItemFromDb = await _db.Item.FindAsync(id);

            _db.Item.Remove(ItemFromDb);
            await _db.SaveChangesAsync();

            Items = await _db.Item.ToListAsync();
            return Page();
        }
    }
}
