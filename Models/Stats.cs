using System.Text.Json.Serialization;

namespace ProjectAPI.Models
{
    public class Stats
    {
        [JsonPropertyName("TotalConfirmed")]
        public long Confirm { get; set; }
        [JsonPropertyName("TotalDeaths")]
        public long Deaths { get; set; }
        [JsonPropertyName("TotalRecovered")]
        public long Recovered { get; set; }
    }
}