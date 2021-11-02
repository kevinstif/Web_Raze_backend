using System.Threading.Tasks;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Persistence.Contexts;

namespace Raze.Api.Users.Persistence.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}