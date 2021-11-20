using System.ComponentModel.DataAnnotations;

namespace Raze.Api.Security.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImgProfile { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public  string Password { get; set; }
        [Required]
        public bool Premium { get; set; }
        [Required]
        public int InterestId { get; set; }
        
        public int ProfessionId { get; set; }
    }
}