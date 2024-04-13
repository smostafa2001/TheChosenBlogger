using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TheChosenBlogger.Application.Contracts.Comment;

namespace TheChosenBlogger.Presentation.RazorPages.Areas.Administrator.Pages.CommentManagement;

public class ListModel(ICommentApplication commentApplication) : PageModel
{
    public List<CommentViewModel> Comments { get; set; } = [];

    public void OnGet() => Comments = commentApplication.GetList();

    public RedirectToPageResult OnPostConfirm(long id)
    {
        commentApplication.Confirm(id);
        return RedirectToPage("./List");
    }

    public RedirectToPageResult OnPostCancel(long id)
    {
        commentApplication.Cancel(id);
        return RedirectToPage("./List");
    }
}
