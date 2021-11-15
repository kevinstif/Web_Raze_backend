namespace Raze.Api.Resources
{
    public class UserAdvisorResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public int Age { get; set; }
        public bool Premium { get; set; }
        public int YearsExperience { get; set; }
        public int Rank { get; set; }
        public int ProfessionId { get; set; }
        public ProfessionResource Profession;
    }
}