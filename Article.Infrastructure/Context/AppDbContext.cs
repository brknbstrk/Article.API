using Microsoft.EntityFrameworkCore;
namespace Article.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticlesComments> ArticleComments { get; set; }
    }
}
