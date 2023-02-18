using System.Collections.Generic;

namespace MasterBlogger.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView GetArticle(long id);
    }
}
