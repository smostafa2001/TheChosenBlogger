using MasterBlogger.Application.Contracts.Article;
using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleAggregate
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
    }
}
