using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MasterBlogger.Domain.CommentAggregate
{
    public interface ICommentRepository:IRepository<long, Comment>
    {
        List<CommentViewModel> GetList();
    }
}
