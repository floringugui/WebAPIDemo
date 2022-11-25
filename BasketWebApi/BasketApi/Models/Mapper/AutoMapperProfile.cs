using AutoMapper;
using BasketBL.BusinessObjects;
using BasketBL.Entities;

namespace BasketApi.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Article, ArticleModel>();
            CreateMap<ArticleModel, Article>();
            CreateMap<Basket, BasketModel>()
                .ForMember(dest => dest.TotalNet, act => act.Ignore())
                .ForMember(dest => dest.TotalGross, act => act.Ignore());
            CreateMap<BasketCreateModel, Basket>();
        }
    }
}