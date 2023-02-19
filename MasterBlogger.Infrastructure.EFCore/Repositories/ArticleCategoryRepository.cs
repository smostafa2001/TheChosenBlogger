using _01.Framework.Infrastructure;
using MasterBlogger.Domain.ArticleCategoryAggregate;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }
    }
}
