using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RushtellSite.Models
{
    public class ApiRushtellSiteModel
    {
        private HttpClient httpClient { get; set; }

        public ApiRushtellSiteModel()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<Client> GetClients()
        {
            string url = @"https://apirushtell.azurewebsites.net/get";

            string dbJson = httpClient.GetStringAsync(url).Result;

            IEnumerable<Client> db = JsonConvert.DeserializeObject<IEnumerable<Client>>(dbJson);

            return db;
        }

        public void AddClient(Client client)
        {
            string url = @"https://apirushtell.azurewebsites.net/create";

            var sendClient = httpClient.PostAsync(
                url,
                new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json")
                ).Result;
        }

        public void DeleteClient(int Id)
        {
            string url = $@"https://apirushtell.azurewebsites.net/delete/{Id}";

            var deleteClient = httpClient.PostAsync(url, default).Result;
        }
    }
}
