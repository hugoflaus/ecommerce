using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence
{
    public class EcommerceDBContext : DbContext
    {
        public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Produtcs { get; set; }
        
    }
}