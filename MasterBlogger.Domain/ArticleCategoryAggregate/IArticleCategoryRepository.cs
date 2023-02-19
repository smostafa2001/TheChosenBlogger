using _01.Framework.Infrastructure;
using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleCategoryAggregate
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
    }
}
