using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly LibraryContext db;
        public TeacherController(LibraryContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return db.Teacher.ToList();
        }

        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return db.Teacher.FirstOrDefault(teacher => teacher.Id == id);
        }

        [HttpPost]
        public bool Post([FromBody]Teacher teacher)
        {
            db.Teacher.Add(teacher);
            bool isSaved = db.SaveChanges(true) != 0;
            return isSaved;
        }

        [HttpPost("update")]
        public bool Update([FromBody]Teacher teacher)
        {
            db.Teacher.Update(teacher);
            bool isSaved = db.SaveChanges(true) != 0;

            return isSaved;
        }

        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            bool isDeleted = false;

            if (id != null)
            {
                Teacher teacher = db.Teacher.FirstOrDefault(a => a.Id == id);
                if (teacher != null)
                {
                    db.Teacher.Remove(teacher);
                    isDeleted = db.SaveChanges(true) != 0;
                }
            }

            return isDeleted;
        }
    }
}
