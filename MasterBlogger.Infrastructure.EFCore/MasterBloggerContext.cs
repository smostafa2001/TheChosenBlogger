using MasterBlogger.Domain.ArticleAggregate;
using MasterBlogger.Domain.ArticleCategoryAggregate;
using MasterBlogger.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MasterBlogger.Infrastructure.EFCore
{
    public class MasterBloggerContext:DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
