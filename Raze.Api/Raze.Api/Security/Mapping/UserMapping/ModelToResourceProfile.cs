using AutoMapper;
using Raze.Api.Resources;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Services.Communication;

namespace Raze.Api.Security.Mapping.UserMapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<User, AuthenticateResponse>();
        }
    }
}