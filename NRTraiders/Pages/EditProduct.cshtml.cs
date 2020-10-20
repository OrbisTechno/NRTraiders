using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public EditProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Product = new Product();
            Product = await _db.Product.FirstOrDefaultAsync(x => x.Id == id);

            Products = new List<Product>();
            Products = await _db.Product.ToListAsync<Product>();
        }

        public async Task<IActionResult> OnPost()
        {
            var ProductFromDb = await _db.Product.FindAsync(Product.Id);

            ProductFromDb.Name = Product.Name;
            ProductFromDb.Description = Product.Description;
            ProductFromDb.ImageUrl = Product.ImageUrl;

            await _db.SaveChangesAsync();

            Products = new List<Product>();
            Products = await _db.Product.ToListAsync<Product>();

            return Page();
        }

    }
}
