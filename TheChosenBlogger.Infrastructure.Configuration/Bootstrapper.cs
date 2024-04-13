using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheChosenBlogger.Application.Contracts.Article;
using TheChosenBlogger.Application.Contracts.ArticleCategory;
using TheChosenBlogger.Application.Contracts.Comment;
using TheChosenBlogger.Application.Implementations;
using TheChosenBlogger.Domain.ArticleAggregate;
using TheChosenBlogger.Domain.ArticleAggregate.Services;
using TheChosenBlogger.Domain.ArticleCategoryAggregate;
using TheChosenBlogger.Domain.ArticleCategoryAggregate.Services;
using TheChosenBlogger.Domain.CommentAggregate;
using TheChosenBlogger.Infrastructure.EFCore;
using TheChosenBlogger.Infrastructure.EFCore.Repositories;
using TheChosenBlogger.Infrastructure.Query;

namespace TheChosenBlogger.Infrastructure.Configuration;

public static class Bootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
        services.AddTransient<IArticleApplication, ArticleApplication>();
        services.AddTransient<IArticleRepository, ArticleRepository>();
        services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
        services.AddTransient<IArticleQuery, ArticleQuery>();
        services.AddTransient<ICommentApplication, CommentApplication>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWorkEf>();
        services.AddDbContext<TheChosenBloggerContext>(options => options.UseSqlServer(connectionString));
    }
}
