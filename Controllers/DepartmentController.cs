
using Microsoft.AspNetCore.Mvc;
using Task5.Data;
using Task5.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department dept)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return Ok(dept);
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_context.Departments.ToList());
        }
    }
}
