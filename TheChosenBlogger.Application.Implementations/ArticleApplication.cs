using Common.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TheChosenBlogger.Application.Contracts.Article;
using TheChosenBlogger.Domain.ArticleAggregate;

namespace TheChosenBlogger.Application.Implementations;

public class ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : IArticleApplication
{
    public void Create(CreateArticle command)
    {
        unitOfWork.BeginTran();
        var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
        articleRepository.Create(article);
        unitOfWork.CommitTran();
    }

    public void Edit(EditArticle command)
    {
        unitOfWork.BeginTran();
        var article = articleRepository.Get(command.Id);
        article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
        unitOfWork.CommitTran();
    }

    public EditArticle Get(long id)
    {
        var article = articleRepository.Get(id);
        return new EditArticle
        {
            Id = article.Id,
            Title = article.Title,
            Image = article.Image,
            ShortDescription = article.ShortDescription,
            Content = article.Content,
            ArticleCategoryId = article.ArticleCategoryId
        };
    }

    public List<ArticleViewModel> GetList() => articleRepository.GetList().Select(x => new ArticleViewModel
    {
        Id = x.Id,
        Title = x.Title,
        ArticleCategory = x.ArticleCategory.Title,
        IsDeleted = x.IsDeleted,
        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
    }).ToList();

    public void Remove(long id)
    {
        unitOfWork.BeginTran();
        var article = articleRepository.Get(id);
        article.Remove();
        unitOfWork.CommitTran();

    }

    public void Activate(long id)
    {
        unitOfWork.BeginTran();
        var article = articleRepository.Get(id);
        article.Activate();
        unitOfWork.CommitTran();
    }
}