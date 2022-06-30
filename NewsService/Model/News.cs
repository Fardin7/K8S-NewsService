using System.ComponentModel.DataAnnotations;

namespace NewsService.Model
{
    public class News
    {
        public int Id { get; set; }

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        [MaxLength(1200)]
        [Required]
        public string Body { get; set; }
        public NewsCategory NewsCategory { get; set; }
        public int NewsCategoryId { get; set; }


    }
}
