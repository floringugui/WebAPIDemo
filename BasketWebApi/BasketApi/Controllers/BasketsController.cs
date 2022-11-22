using BasketApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly ILogger<BasketsController> _logger;

        public BasketsController(ILogger<BasketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{id?}")]
        public BasketModel GetBasket(int id)
        {
            var baskets = Enumerable.Range(1, 5).Select(index => new BasketModel
            {
                Id = index,
                CustomerName = $"Customer {index}",
                TotalGross = index + 10,
                TotalNet = index + 8,
                PaysVAT = index % 2 == 0,
                Articles = new List<ArticleModel>
                {
                    new ArticleModel
                    {
                        Name = "Article 1",
                        Price = 10
                    },
                    new ArticleModel
                    {
                        Name = "Article 2",
                        Price = 20
                    }
                }
            });

            return baskets.FirstOrDefault(x => x.Id == id);
        }
    }
}