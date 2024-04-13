using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TheChosenBlogger.Application.Contracts.Article;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement;

public class ListModel(IArticleApplication articleApplication) : PageModel
{
    public List<ArticleViewModel> Articles { get; set; } = [];

    public void OnGet() => Articles = articleApplication.GetList();
    public RedirectToPageResult OnPostRemove(long id)
    {
        articleApplication.Remove(id);
        return RedirectToPage("./List");
    }
    public RedirectToPageResult OnPostActivate(long id)
    {
        articleApplication.Activate(id);
        return RedirectToPage("./List");
    }
}
