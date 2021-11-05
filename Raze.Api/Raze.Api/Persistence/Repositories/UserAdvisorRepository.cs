using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Persistence.Contexts;
using Raze.Api.Persistence.Repositories;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;

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

        public async Task AddAsync(UserAdvisor userAdvisor)
        {
            await _context.UserAdvisors.AddAsync(userAdvisor);
        }

        public async Task<UserAdvisor> FindbyIdAsync(int id)
        {
            return await _context.UserAdvisors.FindAsync(id);
        }
    }
}