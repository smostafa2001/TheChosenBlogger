using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TheChosenBlogger.Domain.CommentAggregate;
using TheChosenBlogger.Infrastructure.EFCore;

namespace TheChosenBlogger.Infrastructure.Query;

public class ArticleQuery(TheChosenBloggerContext context) : IArticleQuery
{
    public ArticleQueryView GetArticle(long id) => context.Articles.Include(a => a.ArticleCategory)
        .Include(a => a.Comments)
        .Select(a => new ArticleQueryView
        {
            Id = a.Id,
            Title = a.Title,
            ArticleCategory = a.ArticleCategory.Title,
            CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = a.ShortDescription,
            Image = a.Image,
            Content = a.Content,
            CountOfCommnets = a.Comments.Count(c => c.Status == Statuses.Confirmed),
            Comments = MapComments(a.Comments.Where(c => c.Status == Statuses.Confirmed))
        }).FirstOrDefault(a => a.Id == id);

    public List<ArticleQueryView> GetArticles() => [.. context.Articles.Include(a => a.ArticleCategory).Include(a => a.Comments).Select(a => new ArticleQueryView
    {
        Id = a.Id,
        Title = a.Title,
        ArticleCategory = a.ArticleCategory.Title,
        CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
        ShortDescription = a.ShortDescription,
        Image = a.Image,
        CountOfCommnets = a.Comments.Count(c => c.Status == Statuses.Confirmed),
    })];

    private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments) => comments.Select(comment => new CommentQueryView
    {
        Name = comment.Name,
        CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
        Message = comment.Message
    }).ToList();
}
