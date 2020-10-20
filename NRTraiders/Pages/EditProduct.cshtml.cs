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
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Product Product;

        public EditProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Product = new Product();
            Product = await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
