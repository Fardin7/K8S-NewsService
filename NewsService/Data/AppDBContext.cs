using Microsoft.EntityFrameworkCore;
using NewsService.Model;

namespace NewsService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<NewsCategory>()
            //    .HasMany<News>()
            //    .WithOne(q => q.NewsCategory)
            //    .HasForeignKey(q => q.NewsCategoryId);

            modelBuilder.Entity<NewsCategory>()
                .HasData(
                new NewsCategory()
                {
                    Id = 1,
                    Name = "Sport",
                    Description = "this category is about Sport",
                }
               );
            modelBuilder.Entity<News>()
                .HasData(
               
                new News()
                {
                    Id = 1,
                    Title = "Sport news title",
                    Description = "Sport news Description",
                    Body = "Sport news Body",
                    NewsCategoryId = 1,
                },                  
                new News()
                      {
                          Id = 2,
                          Title = "Sport2 news title",
                          Description = "Sport2 news Description",
                          Body = "Sport2 news Body",
                          NewsCategoryId = 1,
                      
                });
              
            base.OnModelCreating(modelBuilder);
        }
    }
}
