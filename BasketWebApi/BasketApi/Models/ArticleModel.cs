using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace BasketApi.Models
{
    public class ArticleModel
    {
        [JsonProperty("article")]
        [JsonPropertyName("article")]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}