using AutoMapper;
using Raze.Api.Resources;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Mapping.UserMapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<UserAdvised, UserAdvisedResource>();
        }
    }
}