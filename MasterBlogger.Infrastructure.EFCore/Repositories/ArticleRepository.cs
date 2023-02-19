using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly MasterBloggerContext _context;
        public ArticleRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }
        public bool DoesExist(string title) => _context.Articles.Any(a => a.Title == title);

        public List<ArticleViewModel> GetList() => _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
        {
            Id = x.Id,
            Title = x.Title,
            ArticleCategory = x.ArticleCategory.Title,
            IsDeleted = x.IsDeleted,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).ToList();
    }
}
