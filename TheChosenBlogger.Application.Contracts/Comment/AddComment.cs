namespace TheChosenBlogger.Application.Contracts.Comment;

public class AddComment
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public long ArticleId { get; set; }
}
