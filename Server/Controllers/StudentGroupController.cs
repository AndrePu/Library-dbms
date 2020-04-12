using System.Collections.Generic;
using System.Linq;using Microsoft.AspNetCore.Mvc;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class StudentGroupController : ControllerBase
    {
        private readonly LibraryContext db;
        public StudentGroupController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Studentgroup> Get()
        {
            return db.Studentgroup.ToList();
        }

        [HttpGet("{id}")]
        public Studentgroup Get(int id)
        {
            return db.Studentgroup.FirstOrDefault(studentGroup => studentGroup.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Studentgroup studentGroup)
        {
            db.Studentgroup.Add(studentGroup);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Studentgroup studentGroup)
        {
            db.Studentgroup.Update(studentGroup);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Studentgroup studentGroup = db.Studentgroup.FirstOrDefault(a => a.Id == id);
                if (studentGroup != null)
                {
                    db.Studentgroup.Remove(studentGroup);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
