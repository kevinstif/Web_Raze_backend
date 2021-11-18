using AutoMapper;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Resources;

namespace Raze.Api.Users.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();

        }
    }
}