using _01.Framework.Infrastructure;
using MasterBlogger.Application.Contracts.Comment;
using MasterBlogger.Domain.CommentAggregate;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MasterBlogger.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
        }
        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Confirm();
            _unitOfWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.Get(id);
            comment.Cancel();
            _unitOfWork.CommitTran();
        }


        public List<CommentViewModel> GetList() => _commentRepository.GetList().Select(x => new CommentViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Message = x.Message,
            Status = x.Status,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            Article = x.Article.Title
        }).ToList();
    }
}
