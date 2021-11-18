using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Mapping.InterestsMapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveInterestResource, Interest>();
        }
    }
}