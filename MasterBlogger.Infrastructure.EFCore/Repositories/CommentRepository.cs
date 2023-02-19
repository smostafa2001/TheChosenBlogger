using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Domain.CommentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBlogger.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void CreateAndSave(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }
    }
}
