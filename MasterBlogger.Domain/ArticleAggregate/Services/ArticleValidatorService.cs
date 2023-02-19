using MasterBlogger.Domain.ArticleCategoryAggregate.Exceptions;

namespace MasterBlogger.Domain.ArticleAggregate.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckRecordExists(string title)
        {
            if (_articleRepository.DoesExist(x=>x.Title == title))
            {
                throw new DuplicatedRecordException();
            }
        }
    }
}
