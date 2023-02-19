using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Domain.CommentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterBlogger.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.CreateAndSave(comment);
        }

        public List<CommentViewModel> GetList() => _commentRepository.GetList();
    }
}
