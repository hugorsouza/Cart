using Cart_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart_API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opt) : base(opt)
        {

        }
        public DbSet<Product> Products { get; set;}
    }
}
