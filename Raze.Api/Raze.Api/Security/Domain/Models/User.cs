using System.Collections.Generic;
using Raze.Api.Domain.Models;

namespace Raze.Api.Users.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgProfile { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int InterestId { get; set; }
        public  string Password { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public bool Premium { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }

        public Interest Interest { get; set; }
        
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}