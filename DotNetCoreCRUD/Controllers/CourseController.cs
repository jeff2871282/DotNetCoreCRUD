using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public CourseController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return db.Courses;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Course>> GetCourseByCourseId(int id)
        {
            return db.Courses.Where(p => p.CourseId == id).ToList();
        }


        //Add
        [HttpPost("")]
        public ActionResult<Course> PostCourse(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();
            return Created("/api/Course/"+model.CourseId,model);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, Course model)
        {
           var c = db.Courses.Find(id);
            c.Title = model.Title;
            c.Credits = model.Credits;
            db.SaveChanges();
            
            return NoContent();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteCourseById(int id)
        {
            var c = db.Courses.Find(id);
            db.Courses.Remove(c);
            db.SaveChanges();
            return Ok(id);
        }
    }
}