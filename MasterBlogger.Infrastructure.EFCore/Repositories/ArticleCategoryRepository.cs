using MasterBlogger.Domain.ArticleCategoryAggregate;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            Save();
        }

        public bool DoesExist(string title) => _context.ArticleCategories.Any(ac => ac.Title == title);

        public ArticleCategory Get(long id) => _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        public List<ArticleCategory> GetAll() => _context.ArticleCategories.OrderByDescending(x => x.Id).ToList();

        public void Save() => _context.SaveChanges();
    }
}
