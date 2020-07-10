using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeesInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {

        Employee[] employees = new Employee[]
        {
            new Employee {
                          id = 1,
                          name = "Juan",
                          contractTypeName = "HourlySalaryEmployee",
                          roleId = 1,
                          roleName = "Administrator",
                          roleDescription = null,
                          hourlySalary = 60000,
                          monthlySalary = 80000
            },
            new Employee {
                          id = 1,
                          name = "Sebastian",
                          contractTypeName = "MonthlySalaryEmployee",
                          roleId = 2,
                          roleName = "Contractor",
                          roleDescription = null,
                          hourlySalary = 60000,
                          monthlySalary = 80000
            }


        };



        // GET: api/Employess
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        // GET: api/Employess/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)

        {
            Employee employee = employees.FirstOrDefault(e => e.id == id);
            return employee;
        }

    }
}
