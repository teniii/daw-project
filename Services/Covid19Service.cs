using System.Threading.Tasks;
using ProjectAPI.Models;
using System.Net.Http;
using System.Text.Json;

namespace ProjectAPI.Services
{
    public class Covid19Service
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<Stats> GetWorldStats()
        {
            var worldStatTsk = client.GetStreamAsync("https://api.covid19api.com/world/total");
            var worldStats = await JsonSerializer.DeserializeAsync<Stats>(await worldStatTsk);
            return worldStats;
        }
    }
}