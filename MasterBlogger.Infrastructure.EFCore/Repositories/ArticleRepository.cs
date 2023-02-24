using _01.Framework.Infrastructure;
using MasterBlogger.Domain.ArticleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public List<Article> GetList() => _context.Articles.Include(x => x.ArticleCategory).ToList();
    }
}
