using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TheChosenBlogger.Infrastructure.Query;

namespace TheChosenBlogger.Presentation.RazorPages.Pages;

public class IndexModel(IArticleQuery articleQuery) : PageModel
{
    public List<ArticleQueryView> Articles { get; set; } = [];

    public void OnGet() => Articles = articleQuery.GetArticles();
}