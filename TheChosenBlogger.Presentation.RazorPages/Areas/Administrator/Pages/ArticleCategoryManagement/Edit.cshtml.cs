using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheChosenBlogger.Application.Contracts.ArticleCategory;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement;

public class EditModel(IArticleCategoryApplication articleCategoryApplication) : PageModel
{
    [BindProperty]
    public RenameArticleCategory ArticleCategory { get; set; } = new();

    public void OnGet(long id) => ArticleCategory = articleCategoryApplication.Get(id);

    public RedirectToPageResult OnPost()
    {
        articleCategoryApplication.Rename(ArticleCategory);
        return RedirectToPage("./List");
    }
}
