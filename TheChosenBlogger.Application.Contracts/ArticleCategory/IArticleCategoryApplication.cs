using System.Collections.Generic;

namespace TheChosenBlogger.Application.Contracts.ArticleCategory;

public interface IArticleCategoryApplication
{
    List<ArticleCategoryViewModel> List();
    void Add(CreateArticleCategory command);
    void Rename(RenameArticleCategory command);
    RenameArticleCategory Get(long id);
    void Remove(long id);
    void Activate(long id);

}
