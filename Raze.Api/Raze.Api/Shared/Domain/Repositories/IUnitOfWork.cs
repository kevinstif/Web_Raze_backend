using System.Threading.Tasks;

namespace Raze.Api.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}