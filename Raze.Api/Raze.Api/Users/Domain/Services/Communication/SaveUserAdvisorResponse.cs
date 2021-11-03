using Raze.Api.Users.Domain.Models;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class SaveUserAdvisorResponse:BaseResponse
    {
        public UserAdvisor UserAdvisor { get; private set; }

        public SaveUserAdvisorResponse(bool success, string message, UserAdvisor userAdvisor) : base(success, message)
        {
            UserAdvisor = userAdvisor;
        }
        public SaveUserAdvisorResponse(UserAdvisor userAdvisor):this(true,string.Empty,userAdvisor){}

        public SaveUserAdvisorResponse(string message):this(false,message,null){}
    }
}
