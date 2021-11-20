using System.Threading.Tasks;
using Raze.Api.Shared.Domain.Repositories;
using Raze.Api.Shared.Persistence.Contexts;

namespace Raze.Api.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
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