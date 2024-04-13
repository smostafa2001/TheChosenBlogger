using Common.Infrastructure;
using System.Collections.Generic;

namespace TheChosenBlogger.Domain.ArticleAggregate;

public interface IArticleRepository : IRepository<long, Article>
{
    public List<Article> GetList();
}
