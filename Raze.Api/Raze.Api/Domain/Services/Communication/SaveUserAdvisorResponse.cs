using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;
using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class SaveUserAdvisorResponse:BaseResponse<AdvisorUser>
    {
        public SaveUserAdvisorResponse(AdvisorUser advisorUser):base(advisorUser){}

        public SaveUserAdvisorResponse(string message):base(message){}
    }
}
