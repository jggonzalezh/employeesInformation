using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.Models
{
    public abstract class EmployeeFactory
    {
        //Factory Method
        public abstract Employee CreateEmployees(Employee e,double annualSalary);
    }
}
