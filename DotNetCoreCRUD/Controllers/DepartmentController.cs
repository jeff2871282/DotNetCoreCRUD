using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public DepartmentController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return db.Departments;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Department>> GetDepartmentById(int id)
        {
            return db.Departments.Where(p => p.DepartmentId == id).ToList();
        }

        [HttpPost("")]
        public ActionResult<Department> PostDepartment(int id,string version)
        {
            db.Departments.FromSqlInterpolated($"SELECT dao.Department_Delete({id},{version})");
            db.SaveChanges();
            return null;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public IActionResult PutDepartment(int id, Department model)
        {
            var c = db.Departments.Find(id);
            c.Name = model.Name;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartmentById(int id)
        {
            var c = db.Departments.Find(id);
            db.Remove(c);
            db.SaveChanges();
            return null;
        }
    }
}