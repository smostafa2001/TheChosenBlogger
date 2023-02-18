namespace MasterBlogger.Domain.ArticleAggregate.Services
{
    public interface IArticleValidatorService
    {
        void CheckRecordExists(string title);
    }
}
