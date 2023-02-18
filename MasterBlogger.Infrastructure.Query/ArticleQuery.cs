using MasterBlogger.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;
        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView GetArticle(long id) => _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Image = x.Image,
            Content = x.Content
        }).FirstOrDefault(x => x.Id == id);

        public List<ArticleQueryView> GetArticles() => _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Image = x.Image
        }).ToList();
    }
}
