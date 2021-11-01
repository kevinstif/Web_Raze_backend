using Raze.Api.Users.Persistence.Contexts;

namespace Raze.Api.Users.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}