using NUnit.Framework;
using Moq;
using EmployeesInfo.DAL;
using EmployeesInfo.BL;
using EmployeesInfo.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tests
{
    public class EmployeeService_createConcreteEmployee
    {
        EmployeeService eService;
        List<Employee> employees;
        public const int numberOfMonthsInAYear = 12;
        public const int hoursWorkedPerMonth = 120;

        [SetUp]
        public void Setup()
        {

            employees = new List<Employee>();

            employees.Add(new Employee
            {
                id = 1,
                name = "Juan",
                contractTypeName = "HourlySalaryEmployee",
                roleId = 1,
                roleName = "Administrator",
                roleDescription = null,
                hourlySalary = 60000,
                monthlySalary = 80000
            });

            employees.Add(
            new Employee
            {
                id = 1,
                name = "Sebastian",
                contractTypeName = "MonthlySalaryEmployee",
                roleId = 2,
                roleName = "Contractor",
                roleDescription = null,
                hourlySalary = 60000,
                monthlySalary = 80000
            });


            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(e => e.GetEmployessAsync()).ReturnsAsync(employees);

            eService = new EmployeeService(employeeRepositoryMock.Object);




        }

        [Test]
        public async Task GetEmployeesAsync_CountAsync()
        {
            List<Employee> concreteEmployees = new List<Employee>();


            List<Employee> employeesObtained = await eService.GetEmployeesAsync();
            Assert.AreEqual(employees.Count, employeesObtained.Count);
        }

   
        [Test]
        public  void createHourlySalaryEmployee()
        {
            List<Employee> concreteEmployees = new List<Employee>();

            Employee employeesObtained = eService.createConcreteEmployee(employees[0]);
    
            Assert.AreEqual(employeesObtained.contractTypeName, ContractTypeName.HourlySalaryEmployee.ToString());
        }


        [Test]
        public  void calculatedEmployeeAnnualSalary_Test()
        {

            double annualSalaryExpected = hoursWorkedPerMonth * employees[0].hourlySalary * numberOfMonthsInAYear;
            double annualSalaryObtained = eService.calculatedHourlySalaryEmployeeAnnualSalary(employees[0]);

            Assert.IsTrue(annualSalaryExpected == annualSalaryObtained);
        }



    }
}