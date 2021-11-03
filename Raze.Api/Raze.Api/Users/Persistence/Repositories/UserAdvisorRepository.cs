using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Persistence.Contexts;

namespace Raze.Api.Users.Persistence.Repositories
{
    public class UserAdvisorRepository:BaseRepository,IUserAdvisorRepository
    {
        public UserAdvisorRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<UserAdvisor>> ListAsync()
        {
            return await _context.UserAdvisors.ToListAsync();
        }
    }
}