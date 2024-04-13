namespace TheChosenBlogger.Application.Contracts.Article;

public class ArticleViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ArticleCategory { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public string CreationDate { get; set; } = string.Empty;
}
