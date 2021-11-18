using System;

namespace Raze.Api.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
        
    }
}