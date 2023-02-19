using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Domain.CommentAggregate;
using System.Collections.Generic;

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
            _commentRepository.Create(comment);
        }
        public void Confirm(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            //_commentRepository.Save();
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            //_commentRepository.Save();
        }


        public List<CommentViewModel> GetList() => _commentRepository.GetList();
    }
}
