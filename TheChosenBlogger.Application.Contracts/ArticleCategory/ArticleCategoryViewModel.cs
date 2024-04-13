namespace TheChosenBlogger.Application.Contracts.ArticleCategory;

public class ArticleCategoryViewModel
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CreationDate { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}
