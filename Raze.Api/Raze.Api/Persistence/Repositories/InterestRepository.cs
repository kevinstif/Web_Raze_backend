using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Persistence.Contexts;

namespace Raze.Api.Persistence.Repositories
{
    public class InterestRepository : BaseRepository, IInterestRepository
    {
        public InterestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Interest>> ListAsync()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task AddAsync(Interest interest)
        {
            await _context.Interests.AddAsync(interest);
        }
    }
}