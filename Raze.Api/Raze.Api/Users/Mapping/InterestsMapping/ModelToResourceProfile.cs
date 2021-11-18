using AutoMapper;
using Raze.Api.Domain.Models;
using Raze.Api.Resources;

namespace Raze.Api.Mapping.InterestsMapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Interest, InterestResource>();
        }
    }
}