using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class PostResponse : BaseResponse<Post>
    {
        protected PostResponse(string message) : base(message)
        {
        }

        public PostResponse(Post post) : base(post)
        {
        }
    }
}