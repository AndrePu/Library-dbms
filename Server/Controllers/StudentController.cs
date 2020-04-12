using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly LibraryContext db;
        public StudentController(LibraryContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Student.ToList();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return db.Student.FirstOrDefault(student => student.Id == id);
        }

        [HttpPost]
        public OperationResult Post([FromBody]Student student)
        {
            OperationResult result = null;

            try
            {
                var addedStudent = db.Student.Add(student).Entity;
                db.SaveChanges(true);
                result = OperationResult<int?>.Ok(addedStudent.Id);
            }
            catch(Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                result = OperationResult.Error(errorMessage);
            }
            return result;
        }

        [HttpPost("update")]
        public OperationResult Update([FromBody]Student student)
        {
            OperationResult result = null;

            try
            {
                db.Student.Update(student);
                db.SaveChanges(true);

                result = OperationResult.Ok();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                result = OperationResult.Error(errorMessage);
            }
            return result;
        }

        [HttpDelete("{id}")]
        public OperationResult Delete(int id)
        {
            OperationResult result;

            try
            {
                Student student = db.Student.FirstOrDefault(a => a.Id == id);
                if (student != null)
                {
                    db.Student.Remove(student);
                    db.SaveChanges(true);
                    result = OperationResult.Ok();
                }
                else
                {
                    result = OperationResult.Error(Errors.StudentNotFoundError);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                result = OperationResult.Error(errorMessage);
            }

            return result;
        }
    }
}
