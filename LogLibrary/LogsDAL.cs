using EntityLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LogsDAL
    {
        public List<Logs> GetAllLogs()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/logs").Result;
            var result = response.Content.ReadAsAsync<List<Logs>>().Result;
            return result;
        }

        public Logs GetLogById(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.GetAsync("api/logs/" + id).Result;
            Logs logs = response.Content.ReadAsAsync<Logs>().Result;
            return logs;
        }

        public bool CreateLog(Logs logs)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/logs/", logs).Result;
            return true;
        }

        public bool UpdateLog(int id, Logs logs)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.PutAsJsonAsync("api/logs/" + id.ToString(), logs).Result;
            return true;
        }

        public bool DeleteLog(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8088/");
            HttpResponseMessage response = client.DeleteAsync("api/logs/" + id.ToString()).Result;
            return true;
        }
    }
}
