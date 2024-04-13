using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TheChosenBlogger.Application.Contracts.ArticleCategory;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement;

public class ListModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
{
    public List<ArticleCategoryViewModel> ArticleCategories { get; set; } = [];

    public void OnGet() => ArticleCategories = articleCategoryApplication.List();

    public RedirectToPageResult OnPostRemove(long id)
    {
        articleCategoryApplication.Remove(id);
        return RedirectToPage("./List");
    }

    public RedirectToPageResult OnPostActivate(long id)
    {
        articleCategoryApplication.Activate(id);
        return RedirectToPage("./List");
    }
}
