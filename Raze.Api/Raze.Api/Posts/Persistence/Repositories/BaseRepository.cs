using Raze.Api.Persistence.Contexts;

namespace Raze.Api.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}