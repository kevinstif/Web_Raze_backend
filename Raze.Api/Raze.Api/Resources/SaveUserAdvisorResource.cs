using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Users.Resources
{
    public class SaveUserAdvisorResource
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public  string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool Premium { get; set; }
        [Required] 
        public string Type { get; set; }
        [Required]
        public int YearsExperience { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public int InterestId { get; set; }
        [Required]
        public int ProfessionId { get; set; }
    }
}