using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class UserAdvisedResponse:BaseResponse<AdvisedUser>
    {
        public UserAdvisedResponse(AdvisedUser advisedUser):base(advisedUser){}

        public UserAdvisedResponse(string message):base(message){}
    }
}
