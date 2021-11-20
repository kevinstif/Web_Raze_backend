using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Security.Domain.Services.Communication
{
    public class UserResponse:BaseResponse<User>
    {
        public UserResponse(User user):base(user){}

        public UserResponse(string message):base(message){}
    }
}