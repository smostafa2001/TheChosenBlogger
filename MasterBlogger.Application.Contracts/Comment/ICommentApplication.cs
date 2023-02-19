using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBlogger.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment command);
    }
}
