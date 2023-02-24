using _01.Framework.Infrastructure;
using MasterBlogger.Domain.CommentAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }
        public List<Comment> GetList() => _context.Comments.Include(x => x.Article).ToList();

    }
}
