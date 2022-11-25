using BasketBL.Enums;
using System.Text.Json.Serialization;

namespace BasketApi.Models
{
    public class BasketCreateModel
    {
        public string Customer { get; set; }

        public bool PaysVAT { get; set; }
    }

    public class BasketModel : BasketCreateModel
    {
        public int Id { get; set; }

        public double TotalNet { get; set; }

        public double TotalGross { get; set; }

        public List<ArticleModel> Articles { get; set; }
    }
}