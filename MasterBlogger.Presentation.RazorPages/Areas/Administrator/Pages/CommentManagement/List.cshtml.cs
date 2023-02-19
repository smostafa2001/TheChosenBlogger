using MasterBlogger.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MasterBlogger.Presentation.RazorPages.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }
    }
}
