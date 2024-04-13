namespace TheChosenBlogger.Domain.ArticleCategoryAggregate.Services;

public interface IArticleCategoryValidatorService
{
    void CheckRecordExists(string title);
}
