using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TheChosenBlogger.Application.Contracts.Article;
using TheChosenBlogger.Application.Contracts.ArticleCategory;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement;

public class EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication) : PageModel
{
    [BindProperty] public EditArticle Article { get; set; } = new();
    public List<SelectListItem> ArticleCategories { get; set; } = [];
    private readonly IArticleApplication _articleApplication = articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication = articleCategoryApplication;

    public void OnGet(long id)
    {
        Article = _articleApplication.Get(id);
        ArticleCategories = _articleCategoryApplication.List().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
    }

    public RedirectToPageResult OnPost()
    {
        _articleApplication.Edit(Article);
        return RedirectToPage("./List");
    }
}
