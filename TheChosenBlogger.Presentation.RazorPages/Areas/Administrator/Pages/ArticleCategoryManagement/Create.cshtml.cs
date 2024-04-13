using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheChosenBlogger.Application.Contracts.ArticleCategory;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement;

public class CreateModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
{
    public void OnGet() { }

    public RedirectToPageResult OnPost(CreateArticleCategory command)
    {
        articleCategoryApplication.Add(command);
        return RedirectToPage("./List");
    }
}
