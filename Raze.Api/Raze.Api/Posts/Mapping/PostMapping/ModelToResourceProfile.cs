using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Mapping.PostMapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Post, PostResource>();
        }
    }
}