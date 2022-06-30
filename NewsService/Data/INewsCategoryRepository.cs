using NewsService.Contract;

namespace NewsService.Data
{
    public interface INewsCategoryRepository
    {
        Task<NewsCategoryRead> Add(NewsCategoryCreate newsCategoryCreate);
        Task<NewsCategoryRead> Update(NewsCategoryUpdate newsCategoryCreate);
        void Remove(NewsCategoryDelete newsCategoryRead);
        Task<NewsCategoryRead> GetById(int id);
    }
}
