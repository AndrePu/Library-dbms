using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class LibrarianController : ControllerBase
    {
        private readonly LibraryContext db;
        public LibrarianController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Librarian> Get()
        {
            return db.Librarian.ToList();
        }

        [HttpGet("{id}")]
        public Librarian Get(int id)
        {
            return db.Librarian.FirstOrDefault(librarian => librarian.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Librarian librarian)
        {
            db.Librarian.Add(librarian);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Librarian librarian)
        {
            db.Librarian.Update(librarian);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Librarian librarian = db.Librarian.FirstOrDefault(a => a.Id == id);
                if (librarian != null)
                {
                    db.Librarian.Remove(librarian);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
