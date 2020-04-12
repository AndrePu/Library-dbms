using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class LibrarycardController : ControllerBase
    {
        private readonly LibraryContext db;
        public LibrarycardController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Librarycard> Get()
        {
            return db.Librarycard.ToList();
        }

        [HttpGet("{id}")]
        public Librarycard Get(int id)
        {
            return db.Librarycard.FirstOrDefault(librarycard => librarycard.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Librarycard librarycard)
        {
            db.Librarycard.Add(librarycard);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Librarycard librarycard)
        {
            db.Librarycard.Update(librarycard);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Librarycard librarycard = db.Librarycard.FirstOrDefault(a => a.Id == id);
                if (librarycard != null)
                {
                    db.Librarycard.Remove(librarycard);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
