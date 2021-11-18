using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Security.Domain.Models;
using Raze.Api.Security.Domain.Repositories;
using Raze.Api.Shared.Persistence.Contexts;
using Raze.Api.Shared.Persistence.Repositories;

namespace Raze.Api.Security.Persistence.Repositories
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
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