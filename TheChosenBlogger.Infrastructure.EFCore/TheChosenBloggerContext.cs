using Microsoft.EntityFrameworkCore;
using TheChosenBlogger.Domain.ArticleAggregate;
using TheChosenBlogger.Domain.ArticleCategoryAggregate;
using TheChosenBlogger.Domain.CommentAggregate;

namespace TheChosenBlogger.Infrastructure.EFCore;

public class TheChosenBloggerContext(DbContextOptions<TheChosenBloggerContext> options) : DbContext(options)
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(TheChosenBloggerContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}
