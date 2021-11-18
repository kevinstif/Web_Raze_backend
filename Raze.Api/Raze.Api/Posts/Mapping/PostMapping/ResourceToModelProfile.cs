using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Mapping.PostMapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePostResource, Post>();
        }
    }
}