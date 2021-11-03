using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class UserAdvisedResponse:BaseResponse
    {
        public UserAdvised UserAdvised { get; private set; }

        public UserAdvisedResponse(bool success, string message, UserAdvised userAdvised) : base(success, message)
        {
            UserAdvised = userAdvised;
        }
        public UserAdvisedResponse(UserAdvised userAdvised):this(true,string.Empty,userAdvised){}

        public UserAdvisedResponse(string message):this(false,message,null){}
    }
}