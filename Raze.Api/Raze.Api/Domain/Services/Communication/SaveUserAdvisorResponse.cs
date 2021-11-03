using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class SaveUserAdvisorResponse:BaseResponse<UserAdvisor>
    {
        public SaveUserAdvisorResponse(UserAdvisor userAdvisor):base(userAdvisor){}

        public SaveUserAdvisorResponse(string message):base(message){}
    }
}
