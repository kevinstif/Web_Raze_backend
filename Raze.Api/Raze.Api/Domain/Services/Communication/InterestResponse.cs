using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class InterestResponse : BaseResponse
    {
        public Interest Interest { get; private set; }
        
        public InterestResponse(bool success, string message, Interest interest) : base(success, message)
        {
            Interest = interest;
        }
        
        // Happy path
        public InterestResponse(Interest interest) : this(true, string.Empty, interest)
        {}
        
        // Unhappy path
        public InterestResponse(string message) : this(false, message, null)
        {}
    }
}