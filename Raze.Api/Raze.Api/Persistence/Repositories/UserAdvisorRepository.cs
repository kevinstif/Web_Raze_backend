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
    public class UserAdvisorRepository:BaseRepository,IUserAdvisorRepository
    {
        public UserAdvisorRepository(AppDbContext context) : base(context)
        {
        }

        public  async Task<IEnumerable<AdvisorUser>> ListAsync()
        {
            return await _context.AdvisorUsers.ToListAsync();
        }

        public async Task AddAsync(AdvisorUser advisorUser)
        {
            await _context.AdvisorUsers.AddAsync(advisorUser);
        }

        public async Task<AdvisorUser> FindbyIdAsync(int id)
        {
            return await _context.AdvisorUsers.FindAsync(id);
        }

        public void Update(AdvisorUser advisorUser)
        {
            _context.AdvisorUsers.Update(advisorUser);
        }

        public void Remove(AdvisorUser advisorUser)
        {
            _context.AdvisorUsers.Remove(advisorUser);
        }
        public async Task<IEnumerable<AdvisorUser>> FindByProfessionId(int id)
        {
            return await _context.AdvisorUsers
                .Where(p => p.ProfessionId == id)
                .Include(p => p.Profession)
                .ToListAsync();
        }
    }
}