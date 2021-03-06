using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Persistence.Contexts;
using Raze.Api.Persistence.Repositories;

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

        public async Task<UserAdvised> FindbyIdAsync(int id)
        {
            return await _context.UserAdviseds.FindAsync(id);
        }

        public void Update(UserAdvised userAdvised)
        {
            _context.UserAdviseds.Update(userAdvised);
        }

        public void Remove(UserAdvised userAdvised)
        {
            _context.UserAdviseds.Remove(userAdvised);
        }
    }
}