namespace Raze.Api.Users.Domain.Models
{
    public class UserAdvised : User
    {
        public UserAdvised() : base()
        {
            
        }
        public int Mood { get; set; }
        
    }
}