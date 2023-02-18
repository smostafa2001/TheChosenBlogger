using MasterBlogger.Application.Contracts.Article;
using MasterBlogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

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
