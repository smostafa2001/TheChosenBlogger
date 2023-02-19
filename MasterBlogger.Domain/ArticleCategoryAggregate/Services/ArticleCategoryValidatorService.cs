using MasterBlogger.Domain.ArticleCategoryAggregate.Exceptions;

namespace MasterBlogger.Domain.ArticleCategoryAggregate.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckRecordExists(string title)
        {
            if (_articleCategoryRepository.DoesExist(title))
            {
                throw new DuplicatedRecordException("This record already exists in the database!");
            }
        }
    }
}
