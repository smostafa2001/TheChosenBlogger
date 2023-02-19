using System.Collections.Generic;

namespace MasterBlogger.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        void Add(AddComment command);
        void Confirm(long id);
        void Cancel(long id);
    }
}
