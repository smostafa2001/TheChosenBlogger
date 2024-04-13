using System.Collections.Generic;

namespace TheChosenBlogger.Infrastructure.Query;

public interface IArticleQuery
{
    List<ArticleQueryView> GetArticles();
    ArticleQueryView GetArticle(long id);
}
