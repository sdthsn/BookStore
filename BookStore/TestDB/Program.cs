using System;
using System.Collections.Generic;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new List<Bookstore>
            {
                new Bookstore { AuthorName = "Shahadat", Name = "My Bio", PublisherName = "MSH Publication", Title = "This is it" },
                new Bookstore { AuthorName = "Kaocher", Name = "Thoughts", PublisherName = "JKH Publication", Title = "Thinking is achieving" }
            };
            var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=bookstore;Integrated Security=True";
            using (var context = new BookstoreDbContext(connectionString))
            {

                x.ForEach(b => { context.Add(b); });           
                context.SaveChanges();

                foreach (var book in context.Bookstores)
                {
                    Console.WriteLine(book.Title);
                }
            }
            Console.ReadKey();
        }
    }
}
