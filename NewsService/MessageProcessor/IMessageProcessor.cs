using NewsService.Contract;

namespace NewsService.MessageProcessor
{
    public interface IMessageProcessor
    {
        Task<NewsCategoryRead> AddCategory(NewsCategoryCreate newsCategoryCreate);
    }
}
