using System.Collections.Generic;
using Raze.Api.Domain.Models;

namespace Raze.Api.Users.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public  string Password { get; set; }
        public int Age { get; set; }
        public bool Premium { get; set; }
        
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
        
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}