using AutoMapper;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Resources;

namespace Raze.Api.Security.Mapping.UserMapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<UpdateUserResource, User>()
                .ForAllMembers(options =>
                options.Condition((source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string) property))
                        return false;
                    return true;
                }));
        }
    }
}