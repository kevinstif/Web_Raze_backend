using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Shared.Persistence.Contexts;
using Raze.Api.Shared.Persistence.Repositories;

namespace Raze.Api.Persistence.Repositories
{
    public class ProfessionRepository : BaseRepository, IProfessionRepository
    {
        public ProfessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Profession>> ListAsync()
        {
            return await _context.Professions.ToListAsync();
        }

        public async Task AddAsync(Profession profession)
        {
            await _context.Professions.AddAsync(profession);
        }
        
        public async Task<Profession> FindByIdAsync(int id)
        {
            return await _context.Professions.FindAsync(id);
        }

        public void Update(Profession profession)
        {
            _context.Professions.Update(profession);
        }

        public void Remove(Profession profession)
        {
            _context.Professions.Remove(profession);
        }
    }
}