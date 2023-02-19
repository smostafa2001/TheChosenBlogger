namespace MasterBlogger.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public byte Status { get; set; }
        public string CreationDate { get; set; }
        public string Article { get; set; }
    }
}
