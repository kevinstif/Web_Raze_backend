using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Raze.Api.Security.Authorization.Handlers.Interfaces;
using Raze.Api.Security.Authorization.Settings;
using Raze.Api.Security.Domain.Services;

namespace Raze.Api.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        
        public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = handler.ValidateToken(token);
            if (userId != null)
            {
                context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            }
            await _next(context);
        }
    }
}