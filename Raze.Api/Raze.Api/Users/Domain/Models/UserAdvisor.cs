namespace Raze.Api.Users.Domain.Models
{
    public class UserAdvisor:User
    {
        public int YearsExperience { get; set; }
        public int Rank { get; set; }
        public string Profession { get; set; }
    }
}