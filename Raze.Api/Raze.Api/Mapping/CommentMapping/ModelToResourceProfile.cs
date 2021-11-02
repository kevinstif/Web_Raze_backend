using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources.CommentResources;

namespace Raze.Api.Mapping.CommentMapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Comment, CommentResource>();
        }
    }
}