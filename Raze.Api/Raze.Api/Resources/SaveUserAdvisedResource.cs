using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Users.Resources
{
    public class SaveUserAdvisedResource
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
        public int Mood { get; set; }
        [Required]
        public int InterestId { get; set; }
    }
}