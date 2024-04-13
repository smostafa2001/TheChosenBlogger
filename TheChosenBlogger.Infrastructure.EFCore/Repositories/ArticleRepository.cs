using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheChosenBlogger.Domain.ArticleAggregate;
using TheChosenBlogger.Infrastructure.EFCore;

namespace TheChosenBlogger.Infrastructure.EFCore.Repositories;

public class ArticleRepository(TheChosenBloggerContext context) : BaseRepository<long, Article>(context), IArticleRepository
{
    public bool DoesExist(string title) => context.Articles.Any(a => a.Title == title);

    public List<Article> GetList() => context.Articles.Include(x => x.ArticleCategory).ToList();
}
