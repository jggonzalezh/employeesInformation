using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesInfo.BL;
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

        private readonly IEmployeeService employeeService;

        public EmployessController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        // GET: api/Employess
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()

        //public async Task<List<Employee>>  Get()
        {
            return await employeeService.GetEmployeesAsync();
        }

        // GET: api/Employess/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<List<Employee>>> Get(int id)
        {

            List<Employee> employees = await employeeService.GetEmployeesAsync();
            List<Employee> employeesConcrete = new List<Employee>();
            var employee = employees.FirstOrDefault(e => e.id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employeesConcrete.Add(employee);

            return Ok(employeesConcrete);


        }

      
    }
}
