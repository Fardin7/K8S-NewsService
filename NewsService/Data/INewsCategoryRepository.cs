using NewsService.Contract;
using NewsService.Model;

namespace NewsService.Data
{
    public interface INewsCategoryRepository
    {
        Task<NewsCategoryRead> Add(NewsCategoryCreate newsCategoryCreate);
        Task<NewsCategoryRead> Update(NewsCategoryUpdate newsCategoryCreate);
        Task<NewsCategory> FindByExternalId(int externalid);
    }
}
