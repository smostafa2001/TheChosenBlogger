using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Comment;
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
        public List<CommentViewModel> GetList() => _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Message = x.Message,
            Status = x.Status,
            CreationDate = x.CreationDate.ToString(),
            Article = x.Article.Title
        }).ToList();

    }
}
