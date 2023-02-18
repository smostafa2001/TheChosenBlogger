using System.Collections.Generic;

namespace MasterBlogger.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle command);
    }
}
