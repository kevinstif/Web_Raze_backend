using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class UserAdvisorResponse:BaseResponse<UserAdvisor>
    {
        public UserAdvisorResponse(UserAdvisor userAdvisor):base(userAdvisor){}

        public UserAdvisorResponse(string message):base(message){}
    }
}