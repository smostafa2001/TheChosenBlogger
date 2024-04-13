using TheChosenBlogger.Domain.ArticleCategoryAggregate.Exceptions;

namespace TheChosenBlogger.Domain.ArticleCategoryAggregate.Services;

public class ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository) : IArticleCategoryValidatorService
{
    public void CheckRecordExists(string title)
    {
        if (articleCategoryRepository.Exists(x => x.Title == title))
            throw new DuplicatedRecordException("This record already exists in the database!");
    }
}
