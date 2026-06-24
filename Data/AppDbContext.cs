using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mini_store.Models;
namespace mini_store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Products> products{get;set;}
    }
}