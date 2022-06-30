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
        public void Remove(NewsCategoryDelete newsCategoryRead)
        {
            _appDbContext.NewsCategory.Remove(_mapper.Map<NewsCategory>(newsCategoryRead));

             _appDbContext.SaveChangesAsync();
        }
        public async Task<NewsCategoryRead> Update(NewsCategoryUpdate newsCategoryCreate)
        {
            var category = await _appDbContext.NewsCategory.FindAsync(newsCategoryCreate.Id);

            category.Description = newsCategoryCreate.Description;
            category.Name = newsCategoryCreate.Name;

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<NewsCategoryRead>(category);
        }
        public async Task<NewsCategoryRead> GetById(int id)
        {
            var newsCategory = await _appDbContext.NewsCategory.FindAsync(id);

            return _mapper.Map<NewsCategoryRead>(newsCategory);
        }
    }
}
