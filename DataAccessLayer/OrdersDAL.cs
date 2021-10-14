using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrdersDAL
    {
        public List<Orders> GetAllOrders()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/orders").Result;
            var result = response.Content.ReadAsAsync<List<Orders>>().Result;
            return result;
        }

        public Orders GetOrderById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/orders/" + id.ToString()).Result;
            try
            {
                Orders orders = response.Content.ReadAsAsync<Orders>().Result;
                return orders;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool CreateOrder(Orders orders)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/orders/", orders).Result;
            return true;
        }

        public bool UpdateOrder(int id, Orders orders)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/orders/" + id.ToString(), orders).Result;
            return true;
        }

        public bool DeleteOrder(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.DeleteAsync("api/orders/" + id.ToString()).Result;
            return true;
        }
    }
}
