using AutoMapper;
using BasketApi.Models;
using BasketBL.Entities;
using BasketBL.Enums;
using BasketBL.Interfaces.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<BasketsController> _logger;
        private readonly IBasketService _basketService;
        private readonly IArticleService _articleService;

        public BasketsController(
            IMapper mapper,
            ILogger<BasketsController> logger,
            IBasketService basketService,
            IArticleService articleService)
        {
            _mapper = mapper;
            _logger = logger;
            _basketService = basketService;
            _articleService = articleService;
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<ActionResult<BasketModel>> GetBasket(int id)
        {
            var basketWithTotals = await _basketService.GetOneWithTotals(id);
            var basketModel = _mapper.Map<BasketModel>(basketWithTotals.Basket);
            basketModel.TotalNet = basketWithTotals.TotalNet;
            basketModel.TotalGross = basketWithTotals.TotalGross;

            return basketModel;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBasket(BasketCreateModel basketCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basket = _mapper.Map<Basket>(basketCreateModel);
            var basketId = await _basketService.Add(basket);

            return basketId;
        }

        [HttpPatch]
        [Route("{id?}")]
        public async Task<ActionResult> UpdateBasketStatus(int id, [FromBody] BasketStatusUpdateModel basketStatusUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Enum.TryParse<BasketStatus>(basketStatusUpdateModel.Status.ToString(), out var basketStatus))
            {
                var basket = new Basket
                {
                    Id = id,
                    Status = basketStatus
                };

                await _basketService.Update(basket);
            }

            return NoContent();
        }

        [HttpPost]
        [Route("{id?}/article-line")]
        public async Task<ActionResult<int>> AddArticleToBasket(int id, [FromBody] ArticleModel articleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basket = await _basketService.GetOne(id);

            var article = _mapper.Map<Article>(articleModel);
            article.Basket = basket;

            var articleId = await _articleService.Add(article);

            return articleId;
        }
    }
}