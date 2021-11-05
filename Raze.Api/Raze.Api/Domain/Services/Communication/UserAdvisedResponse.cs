using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class UserAdvisedResponse:BaseResponse<UserAdvised>
    {
        public UserAdvisedResponse(UserAdvised userAdvised):base(userAdvised){}

        public UserAdvisedResponse(string message):base(message){}
    }
}
