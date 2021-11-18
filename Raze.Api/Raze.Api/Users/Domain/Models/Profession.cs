using System.Collections.Generic;
using Raze.Api.Security.Domain.Models;

namespace Raze.Api.Domain.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public IList<User> User { get; set; } = new List<User>();
    }
}