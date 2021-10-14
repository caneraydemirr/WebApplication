using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeesDAL
    {
        public List<Employees> GetAllEmployees()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/employees").Result;
            var result = response.Content.ReadAsAsync<List<Employees>>().Result;
            return result;
        }

        public Employees GetEmployeeById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/employees/" + id.ToString()).Result;
            try
            {
                Employees employees = response.Content.ReadAsAsync<Employees>().Result;
                return employees;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool CreateEmployee(Employees employees)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/employees/", employees).Result;
            return true;
        }

        public bool UpdateEmployee(int id, Employees employees)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/employees/" + id.ToString(), employees).Result;
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.DeleteAsync("api/employees/" + id.ToString()).Result;
            return true;
        }
    }
}
