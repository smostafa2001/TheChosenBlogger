namespace TheChosenBlogger.Application.Contracts.Article;

public class CreateArticle
{
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public long ArticleCategoryId { get; set; }
}
