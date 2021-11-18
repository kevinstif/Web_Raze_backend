using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}