using Common.Infrastructure;

namespace TheChosenBlogger.Domain.ArticleCategoryAggregate;

public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
{
}
