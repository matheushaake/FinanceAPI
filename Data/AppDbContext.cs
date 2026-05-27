using Microsoft.EntityFrameworkCore;
using FinanceAPI.Models;

namespace FinanceAPI.Data
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Transaction> Transactions { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Transaction>()
                    .Property(t => t.Amount)
                    .HasColumnType("decimal(18,2)");

                modelBuilder.Entity<Transaction>()
                    .Property(t => t.Type)
                    .HasConversion<string>();
            }

        }
    }

