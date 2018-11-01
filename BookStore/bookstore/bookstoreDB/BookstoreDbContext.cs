using bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore.BookstoreDB
{
    public class BookstoreDbContext : DbContext
    {
        private readonly string _connectionString;
        public BookstoreDbContext(string connectionString) : base() 
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Bookstore> Bookstores { get; set; }
    }
}