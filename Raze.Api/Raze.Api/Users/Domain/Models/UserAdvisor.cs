namespace Raze.Api.Users.Domain.Models
{
    public class UserAdvisor:User
    {
        public int YearsExperience { get; set; }
        public int AdvisorRank { get; set; }
        public string AdvisorProfession { get; set; }
    }
}