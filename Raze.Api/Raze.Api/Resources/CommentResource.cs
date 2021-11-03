namespace Raze.Api.Resources.CommentResources
{
    public class CommentResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}