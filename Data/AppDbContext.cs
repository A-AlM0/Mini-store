using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
  // call EntityFrameWork 

using mini_store.Models;

namespace mini_store.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser> // EntityFramework
    {
            public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
            {
                
            }


        public DbSet<Products> Products{get;set;}
        public DbSet<ProductDetails> ProductDetails{get;set;}

        public DbSet<Categories> categories {get;set;}

       
    }

  
}