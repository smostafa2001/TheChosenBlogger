using MasterBlogger.Domain.ArticleCategoryAggregate.Exceptions;
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
                throw new DuplicatedRecordException("This record already exists in the database!");
            }
        }
    }
}
