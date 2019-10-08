using API.Models;
using Microsoft.EntityFrameworkCore;


namespace API.DataAccessLayer
{
    public class FestivoDBContext : DbContext
    {
        public FestivoDBContext()
        {

        }
        public FestivoDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=XIPL9394\SQLEXPRESS;Database=Festivo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasAlternateKey(u => u.Email).HasName("UK_email");
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Categories> categories { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<CartItem> carts { get; set; }
        public DbSet<Checkout> checkouts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderHistory> orders { get; set; }

    }
}