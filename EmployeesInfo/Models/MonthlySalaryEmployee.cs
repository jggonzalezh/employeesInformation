﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesInfo.Models
{
    public class MonthlySalaryEmployee : Employee
    {

        public MonthlySalaryEmployee(Employee e, double annualSalary)
        {
            contractTypeName = ContractTypeName.MonthlySalaryEmployee.ToString();
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
