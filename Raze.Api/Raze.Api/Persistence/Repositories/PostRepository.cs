using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raze.Api.Domain.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Persistence.Contexts;

namespace Raze.Api.Persistence.Repositories
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> ListAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> FindByAdvicedId(int id)
        {
            return await _context.Posts
                .Where(p => p.UserId == id)
                .Include(p => p.UserAdvised)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> FindByAdvisorId(int id)
        {
            return await _context.Posts
                .Where(p => p.UserId == id)
                .Include(p => p.UserAdvisor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> FindByTagId(int id)
        {
            return await _context.Posts
                .Where(p => p.TagId == id)
                .Include(p => p.Tag)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> FindByInterestId(int id)
        {
            return await _context.Posts
                .Where(p => p.InterestId == id)
                .Include(p => p.Interest)
                .ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public async Task<Post> FindByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }

        public void Remove(Post post)
        {
            _context.Posts.Remove(post);
        }
    }
}