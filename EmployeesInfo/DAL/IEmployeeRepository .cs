using EmployeesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.DAL
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetUserAsync();

    }
}
