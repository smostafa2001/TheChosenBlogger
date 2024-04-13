using Common.Infrastructure;
using TheChosenBlogger.Domain.ArticleCategoryAggregate;
using TheChosenBlogger.Infrastructure.EFCore;

namespace TheChosenBlogger.Infrastructure.EFCore.Repositories;

public class ArticleCategoryRepository(TheChosenBloggerContext context) : BaseRepository<long, ArticleCategory>(context), IArticleCategoryRepository
{
}
