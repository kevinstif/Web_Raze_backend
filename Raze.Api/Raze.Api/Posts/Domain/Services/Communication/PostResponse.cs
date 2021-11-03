using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class PostResponse : BaseResponse<Post>
    {
        public PostResponse(Post post) : base(post) { }
        public PostResponse(string message) : base(message) { }
    }
}