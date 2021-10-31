using Raze.Api.Domain.Models;

namespace Raze.Api.Domain.Services.Communication
{
    public class SaveInterestResponse : BaseResponse
    {
        public Interest Interest { get; private set; }
        
        public SaveInterestResponse(bool success, string message, Interest interest) : base(success, message)
        {
            Interest = interest;
        }
        
        // Happy path
        public SaveInterestResponse(Interest interest) : this(true, string.Empty, interest)
        {}
        
        // Unhappy path
        public SaveInterestResponse(string message) : this(false, message, null)
        {}
    }
}