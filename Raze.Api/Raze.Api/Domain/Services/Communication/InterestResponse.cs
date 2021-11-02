using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;

namespace Raze.Api.Domain.Services.Communication
{
    public class InterestResponse : BaseResponse<Interest>
    {
        // Happy path
        public InterestResponse(Interest interest):base(interest) {}
        
        // Unhappy path
        public InterestResponse(string message) : base(message) {}
    }
}