using _01.Framework.Domain;
using MasterBlogger.Domain.ArticleAggregate;
using MasterBlogger.Domain.ArticleCategoryAggregate.Services;
using System;
using System.Collections.Generic;

namespace MasterBlogger.Domain.ArticleCategoryAggregate
{
    public class ArticleCategory : DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; set; }

        protected ArticleCategory()
        {

        }
        public ArticleCategory(string title, IArticleCategoryValidatorService validatorService)
        {
            ValidateArticleCategory(title);
            validatorService.CheckRecordExists(title);
            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void ValidateArticleCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException();
            }
        }

        public void Rename(string title)
        {
            ValidateArticleCategory(title);
            Title = title;
        }

        public void Remove() => IsDeleted = true;
        public void Activate() => IsDeleted = false;

    }
}
