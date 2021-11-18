using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;

namespace Raze.Api.Domain.Services.Communication
{
    public class TagsResponse: BaseResponse<Tag>
    {
        public TagsResponse(Tag tag) : base(tag) {}
        public TagsResponse(string message) : base(message) {}
    }
}