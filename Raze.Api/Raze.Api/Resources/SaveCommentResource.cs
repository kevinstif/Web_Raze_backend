using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Resources.CommentResources
{
    public class SaveCommentResource
    {
        [Required]
        [MaxLength (200)]
        public string Text { get; set; }
        
        [Required]
        public int PostId { get; set; }
    }
}