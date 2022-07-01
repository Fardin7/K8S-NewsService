using AutoMapper;
using NewsService.Dtos;
using NewsService.Model;
using Microsoft.EntityFrameworkCore;
using NewsService.Data;
using NewsService.Contract;

namespace NewsService.Data
{
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        private readonly AppDBContext _appDbContext;
        private readonly IMapper _mapper;

        public NewsCategoryRepository(AppDBContext appDBContext, IMapper mapper)
        {
            _appDbContext = appDBContext;
            _mapper = mapper;
        }
        public async Task<NewsCategoryRead> Add(NewsCategoryCreate newsCategoryCreate)
        {
            var newsCategory = _mapper.Map<NewsCategory>(newsCategoryCreate);

            await _appDbContext.NewsCategory.AddAsync(newsCategory);

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<NewsCategoryRead>(newsCategory);
        }
        public async Task<NewsCategoryRead> Update(NewsCategoryUpdate newsCategoryUpdate)
        {
            var newsCategory = _mapper.Map<NewsCategory>(newsCategoryUpdate);

            var category = await FindByExternalId(newsCategoryUpdate.Id);

            category.Description = newsCategoryUpdate.Description;
            category.Name = newsCategoryUpdate.Name;

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<NewsCategoryRead>(category);
        }
        public async Task<NewsCategory> FindByExternalId(int externalid)
        {
            var category = await _appDbContext.NewsCategory.Where(q => q.ExternalId == externalid).FirstOrDefaultAsync();

            return category;
        }
    }
}
