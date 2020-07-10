using EmployeesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.BL
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();

    }
}
