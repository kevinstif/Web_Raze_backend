using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Persistence.Contexts;

namespace Raze.Api.Users.Persistence.Repositories
{
    public class UserAdvisedRepository:BaseRepository,IUserAdvisedRepository
    {
        public UserAdvisedRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<UserAdvised>> ListAsync()
        {
            return await _context.UserAdviseds.ToListAsync();
        }

        public async Task AddAsync(UserAdvised userAdvised)
        {
            await _context.UserAdviseds.AddAsync(userAdvised);
        }
    }
}