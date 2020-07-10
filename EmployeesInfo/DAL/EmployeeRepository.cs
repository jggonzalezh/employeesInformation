using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using EmployeesInfo.Models;
using System.Text.Json;


namespace EmployeesInfo.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private static string url = "http://masglobaltestapi.azurewebsites.net/api/Employees";


        public async Task<List<Employee>> GetEmployessAsync()
        {
            var employeesJson = await GetStringAsync(url);

            var employees = JsonSerializer.Deserialize<List<Employee>>(employeesJson);
            return employees;
        }


        private static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }


    }
}
