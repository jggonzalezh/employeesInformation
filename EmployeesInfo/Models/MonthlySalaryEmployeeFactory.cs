using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.Models
{
    public  class MonthlySalaryEmployeeFactory : EmployeeFactory
    {

        public override Employee CreateEmployees(Employee e, double annualSalary)
        {
            return new MonthlySalaryEmployee(e, annualSalary);
        }
    }
}
