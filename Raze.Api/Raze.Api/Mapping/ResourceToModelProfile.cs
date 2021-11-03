using AutoMapper;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Resources;

namespace Raze.Api.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserAdvisedResource, UserAdvised>();
        }
    }
}