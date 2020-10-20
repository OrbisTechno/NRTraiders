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
    public class AddProductModel : PageModel
    {

        private ApplicationDbContext _db;

        public AddProductModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Product> Products {get;set;}

        public List<string> Animals = new List<string>();


        public async Task OnGet()
        {
            Products = new List<Product>();
            Products = await _db.Product.ToListAsync<Product>();
        }

        //public async Task OnGet()
        //{
        //    //Products = new List<Product>();
        //    //Products = await _db.Product.ToListAsync<Product>();
        //}

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.AddAsync(Product);
                await _db.SaveChangesAsync();

                return RedirectToPage("AddProduct");
            }
            else
            {
                return Page();
            }
        }


    }
}
