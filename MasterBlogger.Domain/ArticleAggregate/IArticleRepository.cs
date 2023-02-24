using _01.Framework.Infrastructure;
using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleAggregate
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        public List<Article> GetList();
    }
}
