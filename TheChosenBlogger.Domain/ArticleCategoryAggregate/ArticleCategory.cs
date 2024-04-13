using Common.Domain;
using System;
using System.Collections.Generic;
using TheChosenBlogger.Domain.ArticleAggregate;
using TheChosenBlogger.Domain.ArticleCategoryAggregate.Services;

namespace TheChosenBlogger.Domain.ArticleCategoryAggregate;

public class ArticleCategory : DomainBase<long>
{
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public ICollection<Article> Articles { get; set; }

    protected ArticleCategory() { }
    public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
    {
        ValidateArticleCategory(title);
        validatorService.CheckRecordExists(title);
        Title = title;
        IsDeleted = false;
        Articles = [];
    }

    public static void ValidateArticleCategory(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(title);
    }

    public void Rename(string title)
    {
        ValidateArticleCategory(title);
        Title = title;
    }

    public void Remove() => IsDeleted = true;
    public void Activate() => IsDeleted = false;

}
