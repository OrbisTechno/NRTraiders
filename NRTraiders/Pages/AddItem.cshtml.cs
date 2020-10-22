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
    public class AddItemModel : PageModel
    {
        private ApplicationDbContext _db;

        public AddItemModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Item Item { get; set; }

        public List<Item> Items { get; set; }

        public List<string> Animals = new List<string>();

        public List<SelectListItem> ItemTypes { get; set; }
        public async Task OnGet()
        {
            Items = new List<Item>();
            Items = await _db.Item.ToListAsync<Item>();
            //ItemTypes = new List<ItemType>();
            //ItemTypes = await _db.ItemType.ToListAsync<ItemType>();
            ItemTypes = _db.ItemType.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
        }

        //public async Task OnGet()
        //{
        //    //Items = new List<Item>();
        //    //Items = await _db.Item.ToListAsync<Item>();
        //}

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.AddAsync(Item);
                await _db.SaveChangesAsync();
                Items = await _db.Item.ToListAsync();

                ItemTypes = _db.ItemType.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
                return Page();
            }
            else
            {
                return Page();
            }
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ItemFromDb = await _db.Item.FindAsync(id);

            _db.Item.Remove(ItemFromDb);
            await _db.SaveChangesAsync();

            Items = await _db.Item.ToListAsync();

            ItemTypes = _db.ItemType.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
            return RedirectToPage("AddItem");
        }
    }
}
