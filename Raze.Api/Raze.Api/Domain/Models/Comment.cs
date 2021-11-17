using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public AdvisedUser AdvisedUser { get; set; }
        public AdvisorUser AdvisorUser { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}