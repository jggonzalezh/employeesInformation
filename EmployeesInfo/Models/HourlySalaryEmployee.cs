using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.Models
{
    public class HourlySalaryEmployee : Employee
    {

        public  HourlySalaryEmployee(Employee e ,double annualSalary)
        {
            contractTypeName = ContractTypeName.HourlySalaryEmployee.ToString();
            this.id = e.id;
            this.name = e.name;
            this.roleId = e.roleId;
            this.roleName = e.roleName;
            this.roleDescription = e.roleDescription;
            this.hourlySalary = e.hourlySalary;
            this.monthlySalary = e.monthlySalary;
            this.annualSalary = annualSalary;
        }

    }
}
