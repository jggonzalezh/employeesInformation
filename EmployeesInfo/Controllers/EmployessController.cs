using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesInfo.DAL;
using EmployeesInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployessController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        // GET: api/Employess
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()

        //public async Task<List<Employee>>  Get()
        {
            return await employeeRepository.GetUserAsync();
        }

        // GET: api/Employess/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Employee>> Get(int id)
        {

            var employees = await employeeRepository.GetUserAsync();

            var employee = employees.FirstOrDefault(e => e.id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);


        }

      
    }
}
