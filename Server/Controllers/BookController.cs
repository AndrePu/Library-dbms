using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext db;

        public BookController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Book.ToList();
        }
        
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return db.Book.FirstOrDefault(book => book.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Book book)
        {
            db.Book.Add(book);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Book book)
        {
            db.Book.Update(book);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Book book = db.Book.FirstOrDefault(a => a.Id == id);
                if (book != null)
                {
                    db.Book.Remove(book);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
