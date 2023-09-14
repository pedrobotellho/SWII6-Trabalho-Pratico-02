using Microsoft.EntityFrameworkCore;
using SWII6_TP02.Models;

namespace SWII6_TP02
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Container>().HasKey(m => m.Id);
            builder.Entity<Container>()
                .HasOne(c => c.Bill)
                .WithMany(b => b.Containers)
                .HasForeignKey(c => c.IdBill);

            builder.Entity<Bill>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}
