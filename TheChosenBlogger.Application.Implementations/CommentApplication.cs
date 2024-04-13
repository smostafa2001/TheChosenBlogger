using Common.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TheChosenBlogger.Application.Contracts.Comment;
using TheChosenBlogger.Domain.CommentAggregate;

namespace TheChosenBlogger.Application.Implementations;

public class CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : ICommentApplication
{
    public void Add(AddComment command)
    {
        var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
        commentRepository.Create(comment);
    }
    public void Confirm(long id)
    {
        unitOfWork.BeginTran();
        var comment = commentRepository.Get(id);
        comment.Confirm();
        unitOfWork.CommitTran();
    }

    public void Cancel(long id)
    {
        unitOfWork.BeginTran();
        var comment = commentRepository.Get(id);
        comment.Cancel();
        unitOfWork.CommitTran();
    }

    public List<CommentViewModel> GetList() => commentRepository.GetList().Select(x => new CommentViewModel
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
