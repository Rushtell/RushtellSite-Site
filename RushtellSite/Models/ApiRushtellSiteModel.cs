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

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="log"></param>
        /// <param name="pas"></param>
        /// <returns>true/false в зависимости есть ли такой пользователь</returns>
        public bool LoginAccount(string log, string pas)
        {
            string url = $@"https://apirushtell.azurewebsites.net/getacc/{log}/{pas}";

            string loginStr = httpClient.GetStringAsync(url).Result;
            Console.WriteLine(loginStr);

            if (loginStr == "false") return false;

            return true;
        }

        /// <summary>
        /// Регистрация аккаунта
        /// </summary>
        /// <param name="log"></param>
        /// <param name="pas"></param>
        /// <returns>true/false в зависимости удалось ли создать аккаунт</returns>
        public bool RegisterAccount(string log, string pas)
        {
            string url = $@"https://apirushtell.azurewebsites.net/addacc/{log}/{pas}";

            string regStr = httpClient.GetStringAsync(url).Result;
            Console.WriteLine(regStr);

            if (regStr == "false") return false;

            return true;
        }
    }
}
