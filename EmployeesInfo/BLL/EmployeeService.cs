using EmployeesInfo.DAL;
using EmployeesInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeesInfo.BL
{
    public class EmployeeService : IEmployeeService
    {

        public const int numberOfMonthsInAYear = 12;
        public const int hoursWorkedPerMonth = 120;

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        public async Task<List<Employee>> GetEmployeesAsync()
        {

            List<Employee> employees = await employeeRepository.GetEmployessAsync();

            return GetConcreteEmployees(employees);

        }

        public List<Employee> GetConcreteEmployees(List<Employee> employees)
        {
            List<Employee> concreteEmployees = new List<Employee>();

            
            foreach (Employee e in employees)
            {

                if (createConcreteEmployee(e) != null) {
                    concreteEmployees.Add(createConcreteEmployee(e));
                }

            }

            return concreteEmployees;


        }

        public  Employee createConcreteEmployee(Employee e) {

            HourlySalaryEmployeeFactory hourlySalaryEmployeeFactory = new HourlySalaryEmployeeFactory();
            MonthlySalaryEmployeeFactory monthlySalaryEmployeeFactory = new MonthlySalaryEmployeeFactory();
            double annualSalary;

            if (String.Equals(e.contractTypeName, ContractTypeName.HourlySalaryEmployee.ToString()))
            {

                annualSalary = calculatedHourlySalaryEmployeeAnnualSalary(e);
                return hourlySalaryEmployeeFactory.CreateEmployees(e, annualSalary);
            }

            if (String.Equals(e.contractTypeName, ContractTypeName.MonthlySalaryEmployee.ToString()))
            {
                annualSalary = calculatedMonthlySalaryEmployeeAnnualSalary(e);
                return monthlySalaryEmployeeFactory.CreateEmployees(e, annualSalary);
            }

            return null;

        }


        public double calculatedHourlySalaryEmployeeAnnualSalary(Employee e)
        {
            return hoursWorkedPerMonth * e.hourlySalary * numberOfMonthsInAYear;
        }

        public double calculatedMonthlySalaryEmployeeAnnualSalary(Employee e)
        {
            return e.monthlySalary * numberOfMonthsInAYear;
        }

    }
}
