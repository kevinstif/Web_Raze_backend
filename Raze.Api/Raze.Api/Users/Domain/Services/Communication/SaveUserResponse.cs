using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Resources;

namespace Raze.Api.Users.Domain.Services.Communication
{
    public class SaveUserResponse:BaseResponse
    {
       public User User { get;private set; }
        public SaveUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
        public SaveUserResponse(User user):this(true,string.Empty,user){}

        public SaveUserResponse(string message):this(false,message,null){}
        
    }
}