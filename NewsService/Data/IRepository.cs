using NewsService.Dtos;
using NewsService.Contract;
namespace NewsService.Data
{
    public interface IRepository
    {
        Task<NewsRead> Add(NewsCreate newsCreate);
        Task<NewsRead> GetByNewsId(int id);
        Task<IEnumerable<NewsRead>> GetByNewsIdAndCategoryId(int newsid,int categoryid);
        Task<IEnumerable<NewsRead>> Get();
    }
}
