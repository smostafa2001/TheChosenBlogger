namespace TheChosenBlogger.Application.Contracts.Comment;

public class CommentViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public byte Status { get; set; }
    public string CreationDate { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
}
