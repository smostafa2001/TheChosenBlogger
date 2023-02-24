using _01.Framework.Infrastructure;
using System.Collections.Generic;

namespace MasterBlogger.Domain.CommentAggregate
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<Comment> GetList();
    }
}
