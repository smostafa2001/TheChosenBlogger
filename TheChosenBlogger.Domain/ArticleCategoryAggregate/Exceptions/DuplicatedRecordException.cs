using System;

namespace TheChosenBlogger.Domain.ArticleCategoryAggregate.Exceptions;

public class DuplicatedRecordException : Exception
{
    public DuplicatedRecordException() { }
    public DuplicatedRecordException(string message) : base(message) { }
}
