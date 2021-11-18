using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Mapping.ProfessionMapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProfessionResource, Profession>();
        }
    }
}