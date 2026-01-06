using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Task5.Data;
using Task5.DTOs;
using Task5.Models;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeCreateDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok("Employee Added");
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList(); // Lazy Loading
            var result = _mapper.Map<List<EmployeeReadDto>>(employees);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            return Ok(_mapper.Map<EmployeeReadDto>(employee));
        }
    }
}
