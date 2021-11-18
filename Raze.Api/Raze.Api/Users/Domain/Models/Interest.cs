using System.Collections.Generic;
using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        
        public IList<User> User { get; set; } = new List<User>();
        public IList<Post> Posts { get; set; } = new List<Post>();
    }
}