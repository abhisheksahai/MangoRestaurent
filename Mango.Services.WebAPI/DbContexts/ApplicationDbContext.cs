using Mango.Services.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.WebAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}