using Common.Infrastructure;
using System.Collections.Generic;

namespace TheChosenBlogger.Domain.CommentAggregate;

public interface ICommentRepository : IRepository<long, Comment>
{
    List<Comment> GetList();
}
