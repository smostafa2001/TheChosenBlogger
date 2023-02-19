using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleCategoryAggregate
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        ArticleCategory Get(long id);
        void Add(ArticleCategory entity);
        void Save();
        bool DoesExist(string title);

    }
}
