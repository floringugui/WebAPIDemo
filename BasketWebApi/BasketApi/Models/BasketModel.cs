using System.Text.Json.Serialization;

namespace BasketApi.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        
        public int TotalNet { get; set; }
        
        public int TotalGross { get; set; }

        [JsonPropertyName("customer")]
        
        public string CustomerName { get; set; }
        
        public bool PaysVAT { get; set; }
        
        public List<ArticleModel> Articles { get; set; }
    }
}