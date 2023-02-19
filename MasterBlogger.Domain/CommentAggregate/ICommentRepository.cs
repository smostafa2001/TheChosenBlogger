using MasterBlogger.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MasterBlogger.Domain.CommentAggregate
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
        List<CommentViewModel> GetList();
        Comment Get(long id);
        void Save();
    }
}
