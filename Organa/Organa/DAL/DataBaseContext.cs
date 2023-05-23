using Microsoft.EntityFrameworkCore;
using Organa.DAL.Entities;

namespace Organa.DAL
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryPerson> Distributors { get; set;}
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pay> Payments { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chef>().HasIndex(c => c.idChef).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.customerId).IsUnique();
            modelBuilder.Entity<DeliveryPerson>().HasIndex(c => c.deliveryPersonId).IsUnique();
            modelBuilder.Entity<Dish>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Ingredient>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Menu>().HasIndex(c => c.Name).IsUnique();
        }

    }
}
