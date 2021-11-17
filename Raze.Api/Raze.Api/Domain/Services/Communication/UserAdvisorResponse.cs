using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class UserAdvisorResponse:BaseResponse<AdvisorUser>
    {
        public UserAdvisorResponse(AdvisorUser advisorUser):base(advisorUser){}

        public UserAdvisorResponse(string message):base(message){}
    }
}