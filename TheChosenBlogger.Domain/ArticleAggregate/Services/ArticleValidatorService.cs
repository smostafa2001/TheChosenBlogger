using TheChosenBlogger.Domain.ArticleCategoryAggregate.Exceptions;

namespace TheChosenBlogger.Domain.ArticleAggregate.Services;

public class ArticleValidatorService(IArticleRepository articleRepository) : IArticleValidatorService
{
    public void CheckRecordExists(string title)
    {
        if (articleRepository.Exists(x => x.Title == title)) throw new DuplicatedRecordException();
    }
}
