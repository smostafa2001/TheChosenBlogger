using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAggregate;
using System;
using System.Collections.Generic;

namespace MasterBlogger.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);
        }

        public List<ArticleViewModel> GetList() => _articleRepository.GetList();
    }
}
