using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NRTraiders.Data;
using NRTraiders.Models;

namespace NRTraiders.Pages
{
    public class ProductsListModel : PageModel
    {
        public List<Product> Products = new List<Product>();
        

        private readonly ApplicationDbContext _db;
        public ProductsListModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task OnGet()
        {
            Products = await _db.Product.ToListAsync();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var productFromDb = await _db.Product.FindAsync(id);

             _db.Product.Remove(productFromDb);
            await _db.SaveChangesAsync();

            return Page();
        }
    }
}
