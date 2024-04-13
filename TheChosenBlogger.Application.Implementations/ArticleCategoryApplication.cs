using Common.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TheChosenBlogger.Application.Contracts.ArticleCategory;
using TheChosenBlogger.Domain.ArticleCategoryAggregate;
using TheChosenBlogger.Domain.ArticleCategoryAggregate.Services;

namespace TheChosenBlogger.Application.Implementations;

public class ArticleCategoryApplication(
    IArticleCategoryRepository articleCategoryRepository,
    IArticleCategoryValidatorService articleCategoryValidatorService,
    IUnitOfWork unitOfWork
    ) : IArticleCategoryApplication
{
    public void Add(CreateArticleCategory command)
    {
        unitOfWork.BeginTran();
        var articleCategory = new ArticleCategory(command.Title, articleCategoryValidatorService);
        articleCategoryRepository.Create(articleCategory);
        unitOfWork.CommitTran();
    }

    public void Rename(RenameArticleCategory command)
    {
        unitOfWork.CommitTran();
        var articleCategory = articleCategoryRepository.Get(command.Id);
        articleCategory.Rename(command.Title);
        unitOfWork.CommitTran();
    }

    public RenameArticleCategory Get(long id)
    {
        var articleCategory = articleCategoryRepository.Get(id);
        return new RenameArticleCategory
        {
            Id = articleCategory.Id,
            Title = articleCategory.Title,
        };
    }
    public void Remove(long id)
    {
        unitOfWork.BeginTran();
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Remove();
        unitOfWork.CommitTran();
    }

    public void Activate(long id)
    {
        unitOfWork.BeginTran();
        var articleCategory = articleCategoryRepository.Get(id);
        articleCategory.Activate();
        unitOfWork.CommitTran();
    }

    public List<ArticleCategoryViewModel> List() => [.. articleCategoryRepository.GetAll()
        .Select(ac => new ArticleCategoryViewModel
        {
            Id = ac.Id,
            Title = ac.Title,
            IsDeleted = ac.IsDeleted,
            CreationDate = ac.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).OrderByDescending(x => x.Id)];
}
