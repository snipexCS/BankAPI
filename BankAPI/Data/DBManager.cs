using System.ComponentModel.DataAnnotations;
using BankAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace BankAPI.Data
{
    public class DBManager : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = BankDatabaseEF.db;");
        }

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure foreign keys
            modelBuilder.Entity<Account>()
                .HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transactions>()
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey(t => t.AccountNumber)
                .OnDelete(DeleteBehavior.Cascade);

            
            DataSeeder.SeedRandomData(modelBuilder);
        }
    }
}
