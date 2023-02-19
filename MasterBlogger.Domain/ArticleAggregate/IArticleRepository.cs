using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Article;
using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleAggregate
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        public List<ArticleViewModel> GetList();
    }
}
