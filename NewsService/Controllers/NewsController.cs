using Microsoft.AspNetCore.Mvc;
using NewsService.Data;
using NewsService.Dtos;
using NewsService.Contract;

namespace NewsService.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly IRepository _repository;
        public static int RequestCount { get; set; }

        public NewsController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewsCreate newsCreate)
        {
            Console.WriteLine("Updated Category.......!");

            var news = await _repository.Add(newsCreate);

            return Ok(new NewsCategoryRead() { Description= "Description1",Name="name",Id=1500
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.Get());
        }
    }
}
