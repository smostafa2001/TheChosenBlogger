using MasterBlogger.Domain.CommentAggregate;
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

        public ArticleQueryView GetArticle(long id) => _context.Articles.Include(x => x.ArticleCategory)
            .Include(x => x.Comments)
            .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Image = x.Image,
                Content = x.Content,
                CountOfCommnets = x.Comments.Count(z => z.Status == Statuses.CONFIRMED),
                Comments = MapComments(x.Comments.Where(z => z.Status == Statuses.CONFIRMED))
            }).FirstOrDefault(x => x.Id == id);

        public List<ArticleQueryView> GetArticles() => _context.Articles.Include(x => x.ArticleCategory).Include(x => x.Comments).Select(x => new ArticleQueryView
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = x.ShortDescription,
            Image = x.Image,
            CountOfCommnets = x.Comments.Count(z => z.Status == Statuses.CONFIRMED),
        }).ToList();

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments) => comments.Select(comment => new CommentQueryView
        {
            Name = comment.Name,
            CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
            Message = comment.Message
        }).ToList();
    }
}
