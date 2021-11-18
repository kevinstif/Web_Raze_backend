using Raze.Api.Domain.Models;
using Raze.Api.Domain.Services.Comunications;

namespace Raze.Api.Domain.Services.Communication
{
    public class ProfessionResponse : BaseResponse<Profession>
    {
        public ProfessionResponse(Profession profession):base(profession) {}
        
        public ProfessionResponse(string message) : base(message) {}
    }
}