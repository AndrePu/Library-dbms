using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext db;
        public AuthorController(LibraryContext context)
        {
            this.db = context;
        }
        
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return db.Author.ToList();
        }
        
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return db.Author.FirstOrDefault(author => author.Id == id);
        }
        
        [HttpPost]
        public bool Post([FromBody]Author author)
        {
            db.Author.Add(author);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }
        
        [HttpPost("update")]
        public bool Update([FromBody]Author author)
        {
            db.Author.Update(author);
            bool isSaved = db.SaveChanges(true) != 0;
            
            return isSaved;
        }
        
        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Author author = db.Author.FirstOrDefault(a => a.Id == id);
                if (author != null)
                {
                    db.Author.Remove(author);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
