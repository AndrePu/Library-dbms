using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class PublishingHouseController : ControllerBase
    {

        private readonly LibraryContext db;
        public PublishingHouseController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Publishinghouse> Get()
        {
            return db.Publishinghouse.ToList();
        }

        [HttpGet("{id}")]
        public Publishinghouse Get(int id)
        {
            return db.Publishinghouse.FirstOrDefault(publishingHouse => publishingHouse.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Publishinghouse publishingHouse)
        {
            db.Publishinghouse.Add(publishingHouse);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Publishinghouse publishingHouse)
        {
            db.Publishinghouse.Update(publishingHouse);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Publishinghouse publishingHouse = db.Publishinghouse.FirstOrDefault(a => a.Id == id);
                if (publishingHouse != null)
                {
                    db.Publishinghouse.Remove(publishingHouse);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
