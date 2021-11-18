using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Persistence.Contexts;

namespace Raze.Api.Persistence.Repositories
{
    public class TagRepository:BaseRepository,ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task AddAsync(Tag tag)
        { 
            await _context.Tags.AddAsync(tag);
        }

        public async Task<Tag> FindByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> FindByTitleAsync(string title)
        {
            var existingTag = await _context.Tags
                .Where(p => p.Title == title)
                .ToListAsync();
                
            return existingTag;
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }
    }
}