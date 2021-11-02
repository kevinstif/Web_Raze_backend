using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources.CommentResources;

namespace Raze.Api.Mapping.CommentMapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCommentResource, Comment>();
        }
    }
}