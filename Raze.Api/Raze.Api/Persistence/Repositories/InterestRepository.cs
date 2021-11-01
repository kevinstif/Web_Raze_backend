using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Persistence.Contexts;
using Raze.Api.Resources;

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
        
        public async Task<Interest> FindByIdAsync(int id)
        {
            return await _context.Interests.FindAsync(id);
        }
        
        /*public async Task<Interest> FindByTitleAsync(string title)
        {
            return await _context.Interests.FindAsync(title);
        }*/
        
        public void Update(Interest interest)
        {
            _context.Interests.Update(interest);
        }

        public void Remove(Interest interest)
        {
            _context.Interests.Remove(interest);
        }
    }
}