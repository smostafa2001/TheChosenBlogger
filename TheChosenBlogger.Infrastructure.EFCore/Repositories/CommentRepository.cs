using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheChosenBlogger.Domain.CommentAggregate;
using TheChosenBlogger.Infrastructure.EFCore;

namespace TheChosenBlogger.Infrastructure.EFCore.Repositories;

public class CommentRepository(TheChosenBloggerContext context) : BaseRepository<long, Comment>(context), ICommentRepository
{
    public List<Comment> GetList() => context.Comments.Include(x => x.Article).ToList();

}
