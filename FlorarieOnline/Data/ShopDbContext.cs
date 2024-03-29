using FlorarieOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FlorarieOnline.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produs> Produs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Produs> Produse {  get; set; }
        public DbSet<Adres> Adresses { get; set; }

    }
}
