using AutoMapper;
using NewsService.Dtos;
using NewsService.Model;
using NewsService.Contract;
namespace NewsService.Mapper
{
    public class NewsMapper:Profile
    {
        public NewsMapper()
        {
            CreateMap<News, NewsRead>().ForMember(q => q.CategoryName, p => p.MapFrom(src => src.NewsCategory.Name));
            CreateMap<NewsCreate, News>();
            CreateMap<NewsCategoryCreate, NewsCategory>();

            CreateMap<NewsCategoryCreate, NewsCategory>().ForMember(q => q.ExternalId, p => p.MapFrom(x => x.Id)).ForMember(q => q.Id, p => p.Ignore());
            CreateMap<NewsCategoryUpdate, NewsCategory>().ForMember(q => q.ExternalId, p => p.MapFrom(x => x.Id)).ForMember(q => q.Id, p => p.Ignore());
            CreateMap<NewsCategoryDelete, NewsCategory>();

            CreateMap<NewsCategory, NewsCategoryRead>();
            CreateMap<NewsCategoryUpdate, NewsCategoryCreate>();
        }
    }
}
