using System;

namespace MasterBlogger.Domain.ArticleCategoryAggregate.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public void CheckRecordExists(string title)
        {
            if (_articleCategoryRepository.DoesExist(title))
            {
                throw new Exception();
            }
        }
    }
}
