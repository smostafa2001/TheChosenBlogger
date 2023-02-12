using System;

namespace MasterBlogger.Domain.ArticleCategoryAggregate
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title)
        {
            ValidateArticleCategory(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
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
