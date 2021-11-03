using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class SaveUserAdvisedResponse:BaseResponse
    {
        public UserAdvised UserAdvised { get; private set; }

        public SaveUserAdvisedResponse(bool success, string message, UserAdvised userAdvised) : base(success, message)
        {
            UserAdvised = userAdvised;
        }
        public SaveUserAdvisedResponse(UserAdvised userAdvised):this(true,string.Empty,userAdvised){}

        public SaveUserAdvisedResponse(string message):this(false,message,null){}
    }
}