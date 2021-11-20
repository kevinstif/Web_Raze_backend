using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Raze.Api.Domain.Models;

namespace Raze.Api.Security.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgProfile { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int InterestId { get; set; }
        [JsonIgnore]
        public  string PasswordHash { get; set; }
        public string UserType { get; set; }
        public string Username { get; set; }
        public bool Premium { get; set; }
        public int? ProfessionId { get; set; }
        public Profession Profession { get; set; }

        public Interest Interest { get; set; }
        
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}