using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.Models
{
    public class HourlySalaryEmployeeFactory : EmployeeFactory
    {
        public override Employee CreateEmployees(Employee e, double annualSalary)
        {
            return  new HourlySalaryEmployee( e,annualSalary);
        }
    }
}
