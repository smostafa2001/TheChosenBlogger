﻿using Common.Domain;
using TheChosenBlogger.Domain.ArticleAggregate;

namespace TheChosenBlogger.Domain.CommentAggregate;

public class Comment : DomainBase<long>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Message { get; private set; }
    public byte Status { get; private set; }
    public long ArticleId { get; private set; }
    public Article Article { get; private set; }

    protected Comment()
    {

    }

    public Comment(string name, string email, string message, long articleId)
    {
        Name = name;
        Email = email;
        Message = message;
        ArticleId = articleId;
        Status = Statuses.New;
    }

    public void Confirm() => Status = Statuses.Confirmed;
    public void Cancel() => Status = Statuses.Canceled;
}
