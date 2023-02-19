using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.ArticleCategory;
using MasterBlogger.Domain.ArticleCategoryAggregate;
using MasterBlogger.Domain.ArticleCategoryAggregate.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
            _unitOfWork = unitOfWork;
        }

        public void Add(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory command)
        {
            _unitOfWork.CommitTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
            _unitOfWork.CommitTran();
        }

        public RenameArticleCategory Get(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
            };
        }
        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }

        public List<ArticleCategoryViewModel> List() => _articleCategoryRepository.GetAll()
            .Select(ac => new ArticleCategoryViewModel
            {
                Id = ac.Id,
                Title = ac.Title,
                IsDeleted = ac.IsDeleted,
                CreationDate = ac.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).OrderByDescending(x=>x.Id).ToList();

    }
}
