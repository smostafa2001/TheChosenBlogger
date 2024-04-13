using System.Collections.Generic;

namespace TheChosenBlogger.Infrastructure.Query;

public class ArticleQueryView
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string ArticleCategory { get; set; } = string.Empty;
    public string CreationDate { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CountOfCommnets { get; set; }
    public List<CommentQueryView> Comments { get; set; } = [];
}
