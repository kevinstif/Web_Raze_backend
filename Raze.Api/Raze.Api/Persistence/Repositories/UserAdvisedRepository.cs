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

        public  async Task<IEnumerable<AdvisedUser>> ListAsync()
        {
            return await _context.AdvisedUsers.ToListAsync();
        }

        public async Task AddAsync(AdvisedUser advisedUser)
        {
            await _context.AdvisedUsers.AddAsync(advisedUser);
        }

        public async Task<AdvisedUser> FindbyIdAsync(int id)
        {
            return await _context.AdvisedUsers.FindAsync(id);
        }

        public void Update(AdvisedUser advisedUser)
        {
            _context.AdvisedUsers.Update(advisedUser);
        }

        public void Remove(AdvisedUser advisedUser)
        {
            _context.AdvisedUsers.Remove(advisedUser);
        }
    }
}