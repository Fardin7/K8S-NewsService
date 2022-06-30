using System.ComponentModel.DataAnnotations;

namespace NewsService.Dtos
{
    public class NewsCreate
    {

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        [MaxLength(1200)]
        [Required]
        public string Body { get; set; }
        public int NewsCategoryId { get; set; }
    }
}
