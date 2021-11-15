using Raze.Api.Domain.Models;

namespace Raze.Api.Users.Domain.Models
{
    public class UserAdvisor:User
    {
        public int YearsExperience { get; set; }
        public int Rank { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }

    }
}