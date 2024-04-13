using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheChosenBlogger.Application.Contracts.Comment;
using TheChosenBlogger.Infrastructure.Query;

namespace TheChosenBlogger.Presentation.RazorPages.Pages;

public class ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication) : PageModel
{
    public ArticleQueryView Article { get; set; } = new();

    public void OnGet(long id) => Article = articleQuery.GetArticle(id);

    public RedirectToPageResult OnPost(AddComment command)
    {
        commentApplication.Add(command);
        return RedirectToPage("./ArticleDetails", command.ArticleId);
    }
}