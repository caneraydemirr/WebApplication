using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using EntityLayer;

namespace DataAccessLayer
{
    public class ShippersDAL
    {
        public List<Shippers> GetAllShippers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/shippers").Result;
            var result = response.Content.ReadAsAsync<List<Shippers>>().Result;
            return result;
        }

        public Shippers GetShipperById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/shippers/" + id).Result;
            Shippers shippers = response.Content.ReadAsAsync<Shippers>().Result;
            return shippers;
        }

        public bool CreateShipper(Shippers shippers)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/shippers/", shippers).Result;
            return true;
        }

        public bool UpdateShipper(int id, Shippers shippers)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/shippers/" + id.ToString(), shippers).Result;
            return true;
        }

        public bool DeleteShipper(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.DeleteAsync("api/shippers/" + id.ToString()).Result;
            return true;
        }
    }
}
