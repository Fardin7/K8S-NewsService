using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsService.Dtos;
using NewsService.Model;
using NewsService.Contract;
namespace NewsService.Data
{
    public class NewsRepository : IRepository
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;

        public NewsRepository(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }
        public async Task<NewsRead> Add(NewsCreate newsCreate)
        {
            var news = _mapper.Map<News>(newsCreate);

            await _appDBContext.News.AddAsync(news);

            await _appDBContext.SaveChangesAsync();

            return _mapper.Map<NewsRead>(news);
        }
        public async Task<IEnumerable<NewsRead>> Get()
        {
            var news = await _appDBContext.News.ToListAsync();

            var category = await _appDBContext.NewsCategory.ToListAsync();

            var result = new List<NewsRead>();
            news.ForEach(q =>
            {
                var news = _mapper.Map<NewsRead>(q);
                var newscategory = category.Where(z => z.Id == q.NewsCategoryId).FirstOrDefault();
                news.CategoryName = newscategory == null ? "" : newscategory.Name;

                result.Add(news);
            });

            return result;
        }
        public Task<NewsRead> GetByNewsId(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<NewsRead>> GetByNewsIdAndCategoryId(int newsid, int categoryid)
        {
            throw new NotImplementedException();
        }
    }
}
