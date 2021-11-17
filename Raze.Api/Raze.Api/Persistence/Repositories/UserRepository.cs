using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Persistence.Contexts;
using Raze.Api.Persistence.Repositories;
using Raze.Api.Users.Domain.Models;
using Raze.Api.Users.Domain.Repositories;

namespace Raze.Api.Users.Persistence.Repositories
{
    public class UserRepository:BaseRepository,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindbyIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
        public async Task<IEnumerable<User>> FindByProfessionId(int id)
        {
            return await _context.Users
                .Where(p => p.ProfessionId == id)
                .Include(p => p.Profession)
                .ToListAsync();
        }
    }
}