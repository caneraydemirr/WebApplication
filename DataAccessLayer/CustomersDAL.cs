using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomersDAL
    {
        public List<Customers> GetAllCustomers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/customers").Result;
            var result = response.Content.ReadAsAsync<List<Customers>>().Result;
            return result;
        }

        public Customers GetCustomerById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/customers/" + id).Result;
            try
            {
                Customers customers = response.Content.ReadAsAsync<Customers>().Result;
                return customers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateCustomer(Customers customers)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/customers/", customers).Result;
            return true;
        }

        public bool UpdateCustomer(string id, Customers customers)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/customers/" + id.ToString(), customers).Result;
            return true;
        }

        public bool DeleteCustomer(string id)
        {
            return true;
        }
    }
}
