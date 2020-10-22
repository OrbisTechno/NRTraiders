using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NRTraiders.Models;

namespace NRTraiders.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Product> Product { get; set; }



        public DbSet<Item> Item { get; set; }

        public DbSet<ItemType> ItemType { get; set; }
    }
}
