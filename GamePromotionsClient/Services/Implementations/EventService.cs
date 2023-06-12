using GamePromotionsClient.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamePromotionsClient.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IHttpClientFactory _clientFactory;

        public EventService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.json"));
            string url = $"{config["ApiUrl"]}/api/Event";

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

           return JsonConvert.DeserializeObject<List<EventModel>>(responseBody);
        }
    }
}
