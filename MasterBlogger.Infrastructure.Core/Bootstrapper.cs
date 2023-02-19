using _01.Framework.Infrastructure;
using MasterBlogger.Application;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Domain.ArticleAggregate;
using MasterBlogger.Domain.ArticleAggregate.Services;
using MasterBlogger.Domain.ArticleCategoryAggregate;
using MasterBlogger.Domain.ArticleCategoryAggregate.Services;
using MasterBlogger.Domain.CommentAggregate;
using MasterBlogger.Infrastructure.EFCore;
using MasterBlogger.Infrastructure.EFCore.Repositories;
using MasterBlogger.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterBlogger.Infrastructure.Core
{
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
            services.AddDbContext<MasterBloggerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
