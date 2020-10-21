using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class EditItemModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Item Item { get; set; }

        public List<Item> Items { get; set; }

        public List<SelectListItem> ItemTypes { get; set; }

        public EditItemModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Items = new List<Item>();
            Items = await _db.Item.ToListAsync<Item>();
        }


        public async Task<IActionResult> OnPostEdit(int id)
        {

            if (ModelState.IsValid)
            {
                var ItemFromDb = await _db.Item.FindAsync(id);
                ItemFromDb.Name = Item.Name;
                ItemFromDb.Description = Item.Description;
                ItemFromDb.ImageUrl = Item.ImageUrl;
                ItemFromDb.ItemTypeId = Item.ItemTypeId;
                await _db.SaveChangesAsync();
            }

            Item = await _db.Item.FindAsync(id);



            Items = new List<Item>();
            Items = await _db.Item.ToListAsync<Item>();


            ItemTypes = _db.ItemType.Select(a =>
                           new SelectListItem
                           {
                               Value = a.Id.ToString(),
                               Text = a.Name
                           }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ItemFromDb = await _db.Item.FindAsync(Item.Id);

                ItemFromDb.Name = Item.Name;
                ItemFromDb.Description = Item.Description;
                ItemFromDb.ImageUrl = Item.ImageUrl;

                await _db.SaveChangesAsync();

                Items = new List<Item>();
                Items = await _db.Item.ToListAsync<Item>();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ItemFromDb = await _db.Item.FindAsync(id);

            _db.Item.Remove(ItemFromDb);
            await _db.SaveChangesAsync();

            Items = await _db.Item.ToListAsync();
            return RedirectToPage("EditItem");
        }

    }
}
