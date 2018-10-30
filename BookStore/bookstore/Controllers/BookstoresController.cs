using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookstore.BookstoreDB;
using bookstore.Controllers.Resources;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Controllers
{
    [Route("/api/bookstores")]
    public class BookstoresController : Controller
    {
        private readonly IMapper mapper;
        private readonly BookstoreDbContext context;
        public BookstoresController(IMapper mapper, BookstoreDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IEnumerable<BookstoreResource>> GetBookStore(BookstoreResource bookstoreResource)
        {
            var bookstore = await context.Bookstores.ToListAsync();
           // var bookstore = await FakeRepo();
            return mapper.Map<IEnumerable<Bookstore>, IEnumerable<BookstoreResource>>(bookstore);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateBookstore([FromBody] BookstoreResource bookstoreResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookstore = mapper.Map<BookstoreResource, Bookstore>(bookstoreResource);
            
             try
             {

                 context.Bookstores.Add(bookstore);
                 await context.SaveChangesAsync();
             }
             catch(Exception e)
             {
                 throw new Exception(e.Message);
             }
             
            //var books = await FakeRepo();
            //bookstore.Id = books.Count +1;
           // books.Add(bookstore);

            return Ok(bookstore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookstore(int id, [FromBody] BookstoreResource bookstoreResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookstore = await context.Bookstores.FindAsync(id); 
           // var books= await FakeRepo();
            //var bookstore = books.FirstOrDefault(x => x.Id == id);
            if(bookstore == null)
                return NotFound();
            mapper.Map<BookstoreResource, Bookstore>(bookstoreResource, bookstore);
            await context.SaveChangesAsync();
            return Ok(bookstore);
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookstore(int id)
        {
            var bookstore = await context.Bookstores.FindAsync(id);
            if(bookstore == null)
                return NotFound();
            var bookstoreResource = mapper.Map<Bookstore, BookstoreResource>(bookstore);
            return Ok(bookstoreResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookstore(int id)
        {
            var bookstore = await context.Bookstores.FindAsync(id);
            if(bookstore == null)
                return NotFound();
            context.Remove(bookstore);
            await context.SaveChangesAsync();
            return Ok(id);
        }


        private async Task<IList<Bookstore>> FakeRepo()
        {
            var x = new List<Bookstore>
            {
                new Bookstore { Id = 1, AuthorName = "Shahadat", Name = "My Bio", PublisherName = "MSH Publication", Title = "This is it" },
                new Bookstore { Id = 2, AuthorName = "Kaocher", Name = "Thoughts", PublisherName = "JKH Publication", Title = "Thinking is achieving" }
            };
            return x;
        }
    }
}