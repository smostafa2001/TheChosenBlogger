using MasterBlogger.Application.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBlogger.Domain.CommentAggregate
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
        List<CommentViewModel> GetList();
    }
}
