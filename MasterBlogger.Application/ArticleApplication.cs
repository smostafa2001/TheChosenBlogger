using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAggregate;
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
            _articleRepository.Create(article);
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content, command.ArticleCategoryId);
            //_articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
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

        public List<ArticleViewModel> GetList() => _articleRepository.GetList();

        public void Remove(long id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
            //_articleRepository.Save();

        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();
        }

    }
}
