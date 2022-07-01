using AutoMapper;
using NewsService.Contract;
using NewsService.Data;

namespace NewsService.MessageProcessor
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public MessageProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public async Task<NewsCategoryRead> AddCategory(NewsCategoryCreate newsCategoryCreate)
        {
            NewsCategoryRead item = null;
            using (var scope = _scopeFactory.CreateScope())
            {
                var categoryRepository = scope.ServiceProvider.GetRequiredService<INewsCategoryRepository>();

                if (categoryRepository.FindByExternalId(newsCategoryCreate.Id)==null)
                {
                    item = await categoryRepository.Update(_mapper.Map<NewsCategoryUpdate>(newsCategoryCreate));
                }
                else
                {
                    item = await categoryRepository.Add(newsCategoryCreate);

                }
            }
            return item;
        }
    }
}
