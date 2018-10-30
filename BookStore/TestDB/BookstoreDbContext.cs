using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDB
{
    public class BookstoreDbContext : DbContext
    {
        private readonly string connectionString;
        public BookstoreDbContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Bookstore> Bookstores { get; set; }
    }
}
