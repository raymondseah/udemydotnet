using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        // specific name of db, pural is name of table created which contain 2 column depending on the entites
        public DbSet<Product> Products { get; set; }
    }
}